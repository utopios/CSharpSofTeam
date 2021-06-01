using System;
using System.Collections.Generic;
using System.Text;


namespace ExceptionRegex.Classes
{
    class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;

        public Client()
        {

        }

        public Client(string nom, string prenom, string telephone)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
        }

        public int Id { get => id; set => id = value; }
        public string Nom 
        { 
            get => nom;
            set
            {
                if (Tools.IsName(value))                
                    nom = value;                
                else
                    throw new FormatException("Erreur de nom");
            }
        }

        public string Prenom
        { 
            get => prenom;
            set
            {
                if (Tools.IsName(value))                
                    prenom = value;                
                else
                    throw new FormatException("Erreur de prenom");
            }
        }

        public string Telephone
        { 
            get => telephone; 
            set
            {
                if (Tools.IsPhone(value))                
                    telephone = value;                
                else
                    throw new FormatException("Erreur de Téléphone");
            }
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }
    }
}
