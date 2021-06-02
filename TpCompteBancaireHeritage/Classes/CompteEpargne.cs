using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TpCompteBancaireHeritage.Data;

namespace TpCompteBancaireHeritage.Classes
{
    class CompteEpargne : Compte
    {
        private decimal taux;

        public decimal Taux { get => taux; set => taux = value; }

        public CompteEpargne(decimal taux)
        {
            Taux = taux;
        }

        public CompteEpargne(decimal solde, Client client, decimal taux) : base(solde, client)
        {
            Taux = taux;
        }

        public bool CalculeInteret()
        {
            return base.Depot(new Operation(Solde * Taux / 100));
        }
        public override bool AjouterCompte()
        {
            MySqlConnection connection = DataBase.Connection;
            MySqlCommand command = new MySqlCommand("INSERT INTO compte (solde, taux, coutOperation) VALUES (@Solde, @Taux, @coutOperation)", connection);
            command.Parameters.Add(new MySqlParameter("@Solde", Solde ));
            command.Parameters.Add(new MySqlParameter("@Taux", Taux ));
            command.Parameters.Add(new MySqlParameter("@coutOperation",  0 ));
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
    }
}
