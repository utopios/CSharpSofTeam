using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage.Classes
{
    class Mammifere : Animal
    {
        private string nomMammifere;
        private string typeMammifere;

        public Mammifere(string nomMammifere, string typeMammifere) : base(nomMammifere, typeMammifere)
        {
            this.nomMammifere = nomMammifere;
            this.typeMammifere = typeMammifere;
        }

        public string NomMammifere { get => nomMammifere; set => nomMammifere = value; }
        public string TypeMammifere { get => typeMammifere; set => typeMammifere = value; }

        public override void Reproduction()
        {
            Console.WriteLine("Je me reproduit par gestation");
        }

        public new void Oxigenation()
        {
            Console.WriteLine("Inspiration, expiration, j'ai des poumons");
        }


    }
}
