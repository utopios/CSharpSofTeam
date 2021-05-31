using LesStructures.Classes;
using System;

namespace LesStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonneStruc p = new PersonneStruc { Nom = "Toto", Prenom = "Tata" };
            Console.WriteLine(p);
            p.Afficher();
        }
    }
}
