using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage.Classes
{
    class Animal : EtresVivants
    {
        private string nomAnimal;
        private string typeAnimal;

        public Animal(string nomAnimal, string typeAnimal) : base(nomAnimal, typeAnimal)
        {
            this.nomAnimal = nomAnimal;
            this.typeAnimal = typeAnimal;
        }

        public string NomAnimal { get => nomAnimal; set => nomAnimal = value; }
        public string TypeAnimal { get => typeAnimal; set => typeAnimal = value; }

        public override void Naissance()
        {
            Console.WriteLine("Mon coeur bat, je suis vivant");
        }

        public override void Mort()
        {
            Console.WriteLine("Mon coeur à cesser de battre, je suis mort!");
            Vivant = false;
        }

        public override void Alimentation()
        {
            Console.WriteLine("Je mange....");
        }
    }
}
