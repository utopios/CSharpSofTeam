using System;
using System.Collections.Generic;
using System.Text;

namespace LesStructures.Classes
{
    struct PersonneStruc
    {
        private string nom;
        private string prenom;

        public PersonneStruc(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public void Afficher()
        {
            Console.WriteLine($"Nom={Nom}, Prénom={Prenom}");
        }
    }
}
