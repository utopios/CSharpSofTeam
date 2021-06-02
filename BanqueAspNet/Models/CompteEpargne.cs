using System;
using System.Collections.Generic;
using System.Text;

namespace BanqueWeb.Models
{
    public class CompteEpargne : Compte
    {
        private decimal taux;
        
        public decimal Taux { get => taux; set => taux = value; }

        public CompteEpargne(decimal solde, Client client, decimal taux) : base(solde, client)
        {
            Taux = taux;
        }

        public bool CalculeInteret()
        {
            return base.Depot(new Operation(Solde * Taux / 100));
        }

    }
}
