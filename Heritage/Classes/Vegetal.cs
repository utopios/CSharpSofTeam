using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage.Classes
{
    class Vegetal : EtresVivants
    {
        private string nomVegetal;
        private string typeVegetal;
        bool beau;

        public Vegetal(string nomVegetal, string typeVegetal) : base(nomVegetal, typeVegetal)
        {
            this.nomVegetal = nomVegetal;
            this.typeVegetal = typeVegetal;
            beau = true;
        }

        public string NomVegetal { get => nomVegetal; set => nomVegetal = value; }
        public string TypeVegetal { get => typeVegetal; set => typeVegetal = value; }

        public override void Naissance()
        {
            Console.WriteLine("Je pousse du bas vers haut..");
        }

        public override void Mort()
        {
            Console.WriteLine("Je fanne...");
        }

        public override void Alimentation()
        {
            Console.WriteLine("Je me nourris par le racines...");
        }

        public override void Oxigenation()
        {
            base.Oxigenation();
            Console.WriteLine("La nuit je rejette du CO2 et le jour je photosynthèse");
        }

        public override void Expression()
        {
            Console.WriteLine("...");

        }
    }
}
