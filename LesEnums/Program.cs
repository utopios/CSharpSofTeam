using System;

namespace LesEnums
{
    class Program
    {
        static void Main(string[] args)
        {
            Saison a = Saison.Hiver;
            Console.WriteLine($"La valeur numérique de {a} est {(int)a}");

            var b = (Saison)1;
            Console.WriteLine(b);

            var c = (Saison)2;
            Console.WriteLine(c);
        }

        public enum Saison
        {
            Printemps, //0
            Eté,// 1
            Automne, //2
            Hiver //3
        }
    }
}
