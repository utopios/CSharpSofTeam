using System;
using System.Collections.Generic;
using LesExtentionsMethode.Classes;

namespace LesExtentionsMethode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liste = new List<int>() { 1, 2, 3, 4, 5 };
            liste.Shuffle();

            foreach(int i in liste)
            {
                Console.WriteLine(i);
            }
        }
    }
}
