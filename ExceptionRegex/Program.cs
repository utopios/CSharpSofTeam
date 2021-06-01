using System;
using ExceptionRegex.Classes;

namespace ExceptionRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            try
            {
                c.Nom = "Di Persio";
                c.Prenom = "Anthony";
                c.Telephone = "01234";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Je m'execute quelque doit l'issue du Try/Catch");
                //c.Telephone = "0123456789";
            }

            Console.WriteLine(c);
        }
    }
}
