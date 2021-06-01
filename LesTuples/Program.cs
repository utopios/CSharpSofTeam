using System;

namespace LesTuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaration d'un tuple
            (double, int) t1 = (4.5, 3);
            Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

            // Avec variable ayant un nom
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");

            // affichage avec la méthode ToString()
            (double, int) t3 = (4.5, 3);
            Console.WriteLine(t3.ToString());
        }
        public static (int,string, bool) GetTuple()
        {
            return (10, "Toto", true); // Possibilité de discard avec "_" (c#9)
        }
    }
}
