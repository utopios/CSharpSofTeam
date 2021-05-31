using LesInterfaces.Classes;
using System;


namespace LesInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p = new Personne(new Adresse2()) {Nom="Toto", Prenom="Anthony"};
            
            Console.WriteLine(p);
        }
    }
}
