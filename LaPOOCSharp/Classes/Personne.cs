using System;
using System.Collections.Generic;
using System.Text;

namespace LaPOOCSharp.Classes
{
    class Personne : Object
    {
        private static int counter=1;
        private int id;
        private string nom;
        private string prenom;

        public Personne()
        {            
            id = counter;
            counter++;
        }

        public Personne(string nom) :this()
        {
            this.nom = nom;
        }

        public Personne(string nom, string prenom) : this(nom)
        {            
            Nom = nom;
            Prenom = prenom;
        }

        
        public string Nom 
        { 
            get => nom;
            set 
            {
                if (value.Length > 2)
                {
                    nom = value;
                }
                else
                    Console.WriteLine("Le nom doit comporter au moins 3 caractètes...");
            } 
        }
        public string Prenom { get => prenom; set => prenom = value; }

        public override string ToString()
        {
            return $"Id= {id},Nom = {Nom}, Prenom = {Prenom}";
        }
    }
}
