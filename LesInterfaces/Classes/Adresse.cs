using System;
using System.Collections.Generic;
using System.Text;
using LesInterfaces.Interfaces;

namespace LesInterfaces.Classes
{
    class Adresse : IAdresse
    {
        public void AdresseInformation()
        {
            Console.WriteLine("J'affiche l'adresse");
        }
    }
}
