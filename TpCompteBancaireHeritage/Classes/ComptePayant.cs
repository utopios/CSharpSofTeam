using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TpCompteBancaireHeritage.Data;

namespace TpCompteBancaireHeritage.Classes
{
    class ComptePayant : Compte
    {
        private decimal coutOperation;
        public decimal CoutOperation { get => coutOperation; set => coutOperation = value; }

        public ComptePayant(decimal coutOperation)
        {
            CoutOperation = coutOperation;
        }
        public ComptePayant(decimal solde, Client client, decimal coutOperation) : base(solde, client)
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(Operation operation)
        {
            if (operation.Montant > CoutOperation)
            {
                if (base.Depot(operation))
                {
                    return base.Retrait(new Operation(CoutOperation * -1));
                }
            }
            return false;
        }

        public override bool Retrait(Operation operation)
        {
            if (Solde >= Math.Abs(operation.Montant) + CoutOperation)
            {
                if (base.Retrait(operation))
                {
                    return base.Retrait(new Operation(CoutOperation * -1));
                }
            }
            return false;
        }
        public override bool AjouterCompte()
        {
            MySqlConnection connection = DataBase.Connection;
            MySqlCommand command = new MySqlCommand("INSERT INTO compte (solde, taux, coutOperation) VALUES (@Solde, @Taux, @coutOperation)", connection);
            command.Parameters.Add(new MySqlParameter("@Solde", Solde ));
            command.Parameters.Add(new MySqlParameter("@Taux", 0 ));
            command.Parameters.Add(new MySqlParameter("@coutOperation", CoutOperation ));
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
