using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BanqueWeb.Models
{
    public class Operation
    {
        private int id;
        private decimal montant;
        private DateTime dateOperation;
        private static SqlCommand command;
        private static string request;
        private static SqlDataReader reader;
        private static SqlConnection connection;
        private static int compteur = 0;

        public int Id { get => id; set => id = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }

        public Operation(decimal montant)
        {
            Montant = montant;
            DateOperation = DateTime.Now;
            Id = ++compteur;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Date : {DateOperation}, Montant : {Montant}";
        }

        public bool Save(int compteId)
        {
            connection = Connection.New;
            request = "INSERT INTO operation (montant, date_operation, compte_id) values(@montant, @date_operation, @compte_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@montant", Montant));
            command.Parameters.Add(new SqlParameter("@date_operation", DateOperation));
            command.Parameters.Add(new SqlParameter("@compte_id", compteId));
            connection.Open();
            int rw = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return rw > 0;
        }


        public static List<Operation> GetOperationsByCompteId(int id)
        {
            connection = Connection.New;
            List<Operation> liste = new List<Operation>();
            command = new SqlCommand("SELECT montant, date_operation FROM operation WHERE compte_id = @IdCompte", connection);
            command.Parameters.Add(new SqlParameter("@IdCompte", id));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation o = new Operation(reader.GetDecimal(0)) { DateOperation = reader.GetDateTime(1)};
                liste.Add(o);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }
    }
}
