using System;
using LesGenerics.Classes;

namespace LesGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Les éléments génériques (Classe Operation)
            Console.WriteLine("*** Les Elements Génériques *** ");
            Console.WriteLine("Avec les Type int :");
            Operation<int> op1 = new Operation<int>();
            Console.WriteLine(op1.EstEquivalent(2,2));
            Console.WriteLine("Avec les Type Double :");
            Operation<double> op2 = new Operation<double>();
            Console.WriteLine(op2.EstEquivalent(0.58, 0.56));
            Console.WriteLine("Avec les Type String :");
            Operation<string> op3 = new Operation<string>();
            Console.WriteLine(op3.EstEquivalent("Bonjour", "Bonjour3"));
            #endregion


        }
    }
}
