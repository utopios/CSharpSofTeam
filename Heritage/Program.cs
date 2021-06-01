using System;
using Heritage.Classes;

namespace Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            //Chien rex = new Chien("Rex", "Caniche");
            //Console.WriteLine(rex);

            //Pangolin pupuce = new Pangolin("Pupuce", "Pangolin D'asie");
            //Console.WriteLine(pupuce);

            EtresVivants[] tab = new EtresVivants[5];
            EtresVivants etre1 = new Chien("Rex", "Caniche");
            EtresVivants etre2 = new Pangolin("Pupuce", "Pangolin D'asie");
            EtresVivants etre3 = new Vegetal("Cosmos", "Cosmos Sulphureus");
            EtresVivants etre4 = new Animal("Marguerite", "Vache");
            EtresVivants etre5 = new Mammifere("Flipper", "Dauphin");
            tab[0] = etre1;
            tab[1] = etre2;
            tab[2] = etre3;
            tab[3] = etre4;
            tab[4] = etre5;

            //foreach (EtresVivants e in tab)
            //{
            //    Console.WriteLine(e);
            //    e.Naissance();
            //    e.Mort();
            //    e.Alimentation();
            //    e.Reproduction();
            //    e.Expression();
            //    e.Oxigenation();
            //    Console.WriteLine("-------------------------------------------");

            //}
            

            // Convertion de type
            for (int i = 0; i < tab.Length; i++)
            {
                // 1ere solution Unboxing
                if (tab[i].GetType() == typeof(Chien))
                {
                    Chien c = (Chien)etre1;
                    c.Aboyer();
                }

                // 2eme solution => Utiliser les mot "as" pour effectuer notre convertion - Essai ou retourne la valeur par defaut
                Pangolin p = tab[i] as Pangolin;
                if (p!=null)
                {
                    Console.WriteLine(p);
                    if (p.Emmerdant)
                    {
                        Console.WriteLine("J'ai paralisé le monde entier ! ! !");
                    }
                }

                // 3eme solution => En utilisant le mot clé "is" pour effectuer une vérification - Test si possible et effectue la convertion
                if (tab[i] is Vegetal v)
                {
                    Console.WriteLine(v);
                }
            }            
        }
    }    
}
