using System;
using System.Collections.Generic;
using System.Text;

namespace LesDelegues.Classes
{
    class Calculatrice
    {
        //public delegate double DelegateMethodeCalcule(double a, double b);

        //public void Calcule(double a, double b, DelegateMethodeCalcule Methode)
        //{
        //    Console.WriteLine(Methode(a, b));
        //}

        public void Calcule(double a, double b, Func<double, double, double> Methode)
        {
            Console.WriteLine(Methode(a, b));
        }

        //public delegate void DelegateVoid(string s);

        //public void HowToDisplay(string message, DelegateVoid methode)
        //{
        //    methode(message);
        //}

        public void HowToDisplay(string message, Action<string> methode)
        {
            methode(message);
        }
    }
}