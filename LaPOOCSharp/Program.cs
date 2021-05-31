using System;
using LaPOOCSharp.Classes;

namespace LaPOOCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne();
            p1.Nom = "Di Persio";
            p1.Prenom = "Anthony";

            Personne p2 = new Personne { Nom = "Ab", Prenom = "Ihab" };
            //p2.Nom = "Toto";


            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
