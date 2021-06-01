using System;
using System.Data.SqlClient;

namespace CoursAdoNET
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Cours Ado.NET mode Connecté
            // Connection à la base de données
            string connectionString = @"Data Source=(LocalDb)\TestAdoNet;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            // executer les requetes => On utilise un objet Command
            // Préparation de la requêtes
            //string request = "INSERT INTO UTILISATEUR (NOM,PRENOM,TELEPHONE) VALUES ('Toto', 'Titi','0123456789')";
            //string request = "INSERT INTO UTILISATEUR (NOM,PRENOM,TELEPHONE) OUTPUT INSERTED.ID VALUES ('Legrand', 'Zorro','0123456789')";
            //string request = "SELECT * FROM UTILISATEUR";

            //SqlCommand command = new SqlCommand(request, connection);

            // Ouverture Connection
            //connection.Open();

            //// 1ere méthode d'execution dune commande => ExecuteNonQuery() Retourne le nombre de ligne affectées.
            //int nbLigne = command.ExecuteNonQuery();
            //Console.WriteLine(nbLigne);// Juste pour vérifier

            //// 2eme méthode d'execution de la commande => ExecuteScalar() Retourne le champ demandé dans la requete (Ici ID)
            //int id = (int)command.ExecuteScalar();
            //Console.WriteLine(id);// Juste pour vérifier

            //// 3eme méthode d'éxecution de la commande => Retourne l'ensemble des résultat de la requete
            //SqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine($"Id:{reader.GetInt32(0)}, Nom: {reader.GetString(1)}, Prenom: {reader.GetString(2)} ");
            //}

            //// Fermeture du reader
            //reader.Close();

            //// Liberation de l'objet command
            //command.Dispose();

            //// Fermer la connection
            //connection.Close();

            #region Avec des variable utilisateur
            Console.Write("Veuillez inserer un nom : ");
            string nom = Console.ReadLine();

            Console.Write("Veuillez inserer un prenom : ");
            string prenom = Console.ReadLine();

            Console.Write("Veuillez inserer un téléphone : ");
            string telephone = Console.ReadLine();

            // avec des valeur numérique
            //int i = Convert.ToInt32(Console.ReadLine());

            // Préparation de la requete
            string request = "INSERT INTO UTILISATEUR (NOM,PRENOM,TELEPHONE) VALUES (@Nom, @Prenom, @Telephone)";
            SqlCommand command = new SqlCommand(request, connection);
            // Ajout des paramètres de la commande
            command.Parameters.Add(new SqlParameter("@Nom", nom));
            command.Parameters.Add(new SqlParameter("@Prenom", prenom));
            command.Parameters.Add(new SqlParameter("@Telephone", telephone));

            // Execution de la commande
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            #endregion

            #endregion
        }
    }
}
