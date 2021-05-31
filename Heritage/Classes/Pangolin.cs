using System;
using System.Collections.Generic;
using System.Text;

namespace Heritage.Classes
{
    sealed class Pangolin : Mammifere
    {
        private string nomPangolin;
        private string typePangolin;
        private bool emmerdant;

        public Pangolin(string nomPangolin, string typePangolin) :base(nomPangolin,typePangolin)
        {
            this.nomPangolin = nomPangolin;
            this.typePangolin = typePangolin;
            Emmerdant = true;
        }

        public Pangolin(string nomPangolin, string typePangolin, bool Emmerdant) : this(nomPangolin, typePangolin)
        {
            NomPangolin = nomPangolin;
            TypePangolin = typePangolin;
            this.Emmerdant = Emmerdant;
        }

        public string NomPangolin { get => nomPangolin; set => nomPangolin = value; }
        public string TypePangolin { get => typePangolin; set => typePangolin = value; }
        public bool Emmerdant { get => emmerdant; set => emmerdant = value; }
    }
}
