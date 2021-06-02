using System;
using System.Collections.Generic;
using System.Text;

namespace BanqueWeb.Models
{
    public class ComptePayant : Compte
    {
        private decimal coutOperation;
        public decimal CoutOperation { get => coutOperation; set => coutOperation = value; }

        public ComptePayant(decimal solde, Client client, decimal coutOperation) : base(solde, client)
        {
            CoutOperation = coutOperation;
        }

        public override bool Depot(Operation operation)
        {
            if(operation.Montant > CoutOperation)
            {
                if(base.Depot(operation))
                {
                    return base.Retrait(new Operation(CoutOperation * -1));
                }
            }
            return false;
        }

        public override bool Retrait(Operation operation)
        {
            if(Solde >= Math.Abs(operation.Montant) + CoutOperation)
            {
                if(base.Retrait(operation))
                {
                    return base.Retrait(new Operation(CoutOperation * -1));
                }
            }
            return false;
        }
    }
}
