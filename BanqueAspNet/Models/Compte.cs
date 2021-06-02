using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BanqueWeb.Models
{
    public class Compte
    {
        private int id;
        private decimal solde;
        private Client client;
        private List<Operation> operations;
        private static SqlCommand command;
        private static string request;
        private static SqlDataReader reader;

        
        public int Id { get => id; set => id = value; }
        public decimal Solde { get => solde; set => solde = value; }
        public Client Client { get => client; set => client = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }

        public event Action<decimal, int> ADecouvert;

        public Compte()
        {
            Operations = new List<Operation>();
        }
        public Compte(decimal solde, Client client) : this()
        {
            Solde = solde;
            Client = client;      
        }

        public virtual bool Depot(Operation operation)
        {
            if (operation.Montant > 0)
            {
                if(operation.Save(Id))
                {
                    Operations.Add(operation);
                    Solde += operation.Montant;

                    return Update();
                }
                
            }
            return false;
        }

        public virtual bool Retrait(Operation operation)
        {
            if (operation.Montant < 0 /*&& Math.Abs(operation.Montant) <= Solde*/)
            {
                if (operation.Save(Id))
                {
                    Operations.Add(operation);
                    Solde += operation.Montant;
                    if (Solde < 0)
                    {
                        if (ADecouvert != null)
                        {
                            ADecouvert(Solde, Id);
                        }
                    }
                    return Update();
                }
                    
            }
            return false;
        }


        public bool Save()
        {
            request = "INSERT INTO compte (solde, client_id) OUTPUT INSERTED.ID VALUES (@Solde, @clientId)";
            SqlConnection connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@Solde", Solde));
            command.Parameters.Add(new SqlParameter("@clientId", Client.Id));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();

            return Id > 0;
        }

        public bool Update()
        {
            request = "UPDATE compte set solde = @solde where id = @id";
            SqlConnection connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@solde", Solde));
            command.Parameters.Add(new SqlParameter("@id", Id));
            connection.Open();
            int rw = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return rw > 0;
        }

        public static Compte GetCompteById(int id)
        {
            Compte compte = null;
            request = "SELECT c.solde, c.client_id, cl.nom, cl.prenom, cl.telephone" +
                " FROM compte as c inner join client as cl on c.client_id = cl.id where c.id = @id";
            SqlConnection connection = Connection.New;
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                compte = new Compte()
                {
                    Id = id,
                    Solde = reader.GetDecimal(0),
                    Client = new Client()
                    {
                        Id = reader.GetInt32(1),
                        Nom = reader.GetString(2),
                        Prenom = reader.GetString(3),
                        Telephone = reader.GetString(4)
                    }
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return compte;
        }
        public override string ToString()
        {
            string result = $"Client : {Client}\n";
            Operations.ForEach(o =>
            {
                result += $"{o}\n";
            });
            result += $"Solde {Solde}";
            return result;
        }
    }
}
