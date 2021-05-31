using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage.Classes
{
    class Chien : Mammifere
    {
        private string nomChien;
        private string typeChien;

        public Chien(string nomChien, string typeChien) : base(nomChien, typeChien)
        {
            this.nomChien = nomChien;
            this.typeChien = typeChien;
        }

        public string NomChien { get => nomChien; set => nomChien = value; }
        public string TypeChien { get => typeChien; set => typeChien = value; }

        public override void Alimentation()
        {
            Console.WriteLine("Je mange des croquettes...");
        }

        public void Aboyer()
        {
            base.Expression();
            Console.WriteLine("Wouarf... Wouaf");
        }
    }
}
