using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TpCompteBancaireHeritage.Data;

namespace TpCompteBancaireHeritage.Classes
{
    class Compte
    {
        private int id;
        private decimal solde;
        private Client client;
        private List<Operation> operations;

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
        public virtual bool AjouterCompte()
        {
            MySqlConnection connection = DataBase.Connection;
            MySqlCommand command = new MySqlCommand("INSERT INTO compte (solde, taux, coutOperation) VALUES (@Solde, @Taux, @coutOperation)", connection);
            command.Parameters.Add(new MySqlParameter("@Solde", MySqlDbType.Decimal) { Value = Solde });
            command.Parameters.Add(new MySqlParameter("@Taux", MySqlDbType.Decimal) { Value = 0 });
            command.Parameters.Add(new MySqlParameter("@coutOperation", MySqlDbType.Decimal) { Value = 0 });
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            command = new MySqlCommand("SELECT LAST_INSERT_ID() FROM compte", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Id = reader.GetInt32(0);
            }
            reader.Close();
            command.Dispose();
            command = new MySqlCommand("INSERT INTO clientCompte (idClient, idCompte) VALUES (@IdClient, @IdCompte)", connection);
            command.Parameters.Add(new MySqlParameter("@IdClient", Client.Id));
            command.Parameters.Add(new MySqlParameter("@IdCompte", Id));
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbLigne > 0)
                return true;
            else
                return false;
        }

        public static Compte RechercherCompte(int id)
        {
            Compte compte = null;
            MySqlConnection connection = DataBase.Connection;
            string request = "SELECT cb.Id, cb.nom, cb.prenom, cb.telephone, c.solde, c.taux, c.coutOperation " +
                "FROM compte as c " +
                "INNER JOIN clientCompte AS cc ON c.Id = cc.Idcompte " +
                "INNER JOIN clientBanque AS cb ON cc.IdClient = cb.Id " +
                "WHERE cc.IdCompte = @IdCompte ";
            MySqlCommand command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@IdCompte",  id ));
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetDecimal(5) > 0)
                {
                    compte = new CompteEpargne(reader.GetDecimal(5));
                }
                else if (reader.GetDecimal(6) > 0)
                {
                    compte = new ComptePayant(reader.GetDecimal(6));
                }
                else
                {
                    compte = new Compte();
                }
                if (compte != null)
                {
                    compte.Client = new Client() { Id = reader.GetInt32(0), Nom = reader.GetString(1), Prenom = reader.GetString(2), Telephone = reader.GetString(3) };
                    compte.Id = id;
                    compte.Solde = reader.GetDecimal(4);
                    compte.Operations = Operation.ChercherOperationParCompte(compte);
                    compte.ADecouvert += ActionNotificationDecouvert;
                }
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return compte;
        }
        public virtual bool Depot(Operation operation)
        {
            if (operation.Montant > 0)
            {
                if (operation.AjouterOperation(Id) > 0)
                {
                    Solde += operation.Montant;
                    if (MiseAJourCompte() > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }

        public virtual bool Retrait(Operation operation)
        {
            if (operation.Montant < 0)
            {
                if (operation.AjouterOperation(Id) > 0)
                {
                    Solde += operation.Montant;
                    if (MiseAJourCompte() > 0)
                    {
                        if (Solde < 0)
                        {
                            if (ADecouvert != null)
                            {
                                ADecouvert(Solde, Id);
                            }
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }

        public int MiseAJourCompte()
        {
            MySqlConnection connection = DataBase.Connection;
            MySqlCommand command = new MySqlCommand("UPDATE compte SET solde = @Solde WHERE id = @Id", connection);
            command.Parameters.Add(new MySqlParameter("@Solde", Solde));
            command.Parameters.Add(new MySqlParameter("@Id", Id));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLigne;
        }

        public static void ActionNotificationDecouvert(decimal solde, int numero)
        {
            Console.WriteLine($"Le compte numéro {numero} est à découvert, voici le nouveau solde {solde}");
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
