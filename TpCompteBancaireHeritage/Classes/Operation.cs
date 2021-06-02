using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TpCompteBancaireHeritage.Data;

namespace TpCompteBancaireHeritage.Classes
{
    class Operation
    {
        private int id;
        private int idCompte;
        private decimal montant;
        private DateTime dateOperation;

        public int Id { get => id; set => id = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }
        public int IdCompte { get => idCompte; set => idCompte = value; }

        public Operation(decimal montant)
        {
            Montant = montant;
            DateOperation = DateTime.Now;
        }

        public Operation(int Id, int IdCompte, DateTime date, decimal montant)
        {
            this.Id = Id;
            this.IdCompte = IdCompte;
            Montant = montant;
            DateOperation = date;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Date : {DateOperation}, Montant : {Montant}";
        }

        public int AjouterOperation(int idCompte)
        {
            MySqlConnection connection = DataBase.Connection;
            MySqlCommand command = new MySqlCommand("INSERT INTO operation (idCompte,dateOperation, montant) VALUES (@IdCompte, @DateOperation, @Montant)", connection);
            command.Parameters.Add(new MySqlParameter("@IdCompte", idCompte));
            command.Parameters.Add(new MySqlParameter("@DateOperation", DateOperation));
            command.Parameters.Add(new MySqlParameter("@Montant", Montant));
            connection.Open();
            int nbLigne = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbLigne;
        }

        public static List<Operation> ChercherOperationParCompte(Compte c)
        {
            MySqlConnection connection = DataBase.Connection;
            List<Operation> liste = new List<Operation>();
            MySqlCommand command = new MySqlCommand("SELECT * FROM operation WHERE idcompte = @IdCompte", connection);
            command.Parameters.Add(new MySqlParameter("@IdCompte", c.Id));
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Operation o = new Operation(reader.GetInt32(0), c.Id, reader.GetDateTime(2), reader.GetDecimal(3));
                liste.Add(o);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return liste;
        }
    }
}
