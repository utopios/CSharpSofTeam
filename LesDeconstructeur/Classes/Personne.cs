using System;
using System.Collections.Generic;
using System.Text;

namespace LesDeconstructeur.Classes
{
    class Personne
    {
        private int id;
        private string nom;
        private string prenom;

        public Personne(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public void Deconstruct( out string nom, out string prenom)
        {
            nom = Nom;
            prenom = Prenom;
        }

        public override string ToString()
        {
            return $"Id= {Id}, Nom= {Nom}, Prénom ={Prenom}";
        }
    }
}
