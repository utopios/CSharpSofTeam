using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage.Classes
{
    abstract class EtresVivants
    {
        bool vivant;
        private string nom;
        private string type;

        protected EtresVivants(string nom, string type)
        {
            Vivant = true;
            Nom = nom;
            Type = type;
        }

        public bool Vivant { get => vivant; set => vivant = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return $"Nom: {Nom}, Type={type}";
        }

        public virtual void Naissance()
        {
            Console.WriteLine("Tout les êtres vivant naissent...");
        }

        public virtual void Mort()
        {
            Console.WriteLine("Tout les êtres vivant meurent...");
        }

        public abstract void Alimentation();

        public virtual void Reproduction()
        {
            Console.WriteLine("Tout les êtres vivant se reproduisent...");
        }

        public virtual void Expression()
        {
            Console.WriteLine("Tout les êtres vivant s'expriment...");
        }

        public virtual void Oxigenation()
        {
            Console.WriteLine("Tout les êtres vivant doivent s'oxigener...");
        }
    }
}
