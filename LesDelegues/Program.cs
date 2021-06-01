using System;
using LesDelegues.Classes;

namespace LesDelegues
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculatrice c = new Calculatrice();
            c.Calcule(10.0, 20.0, Addition);
            c.Calcule(10.0, 20.0, delegate (double a, double b) { return a - b; });
            c.Calcule(10.0, 20.0, (double a, double b) => { return a * b; });
            c.Calcule(10.0, 20.0, (a, b) => a / b );

            c.HowToDisplay("Salut", AfficherPlus);
        }

        public static double Addition(double a, double b) { return a + b; }

        public static void Afficher(string s) { Console.WriteLine(s); }
        public static void AfficherPlus(string s) { Console.WriteLine(s + " Et j'en affiche Plus..."); }
    }
}
