using System;
using LesDeconstructeur.Classes;

namespace LesDeconstructeur
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p = new Personne(1, "Toto", "Titi");
            Console.WriteLine(p);

            var (nom, prenom) = p;
            Console.WriteLine(nom);
        }
    }
}
