using System;
using System.Collections.Generic;
using System.Linq;
using LesGenerics.Classes;

namespace LesGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Les éléments génériques (Classe Operation)
            Console.WriteLine("*** Les Elements Génériques *** ");
            Console.WriteLine("Avec les Type int :");
            Operation<int> op1 = new Operation<int>();
            Console.WriteLine(op1.EstEquivalent(2,2));
            Console.WriteLine("Avec les Type Double :");
            Operation<double> op2 = new Operation<double>();
            Console.WriteLine(op2.EstEquivalent(0.58, 0.56));
            Console.WriteLine("Avec les Type String :");
            Operation<string> op3 = new Operation<string>();
            Console.WriteLine(op3.EstEquivalent("Bonjour", "Bonjour3"));
            #endregion

            #region Les Queue<> FIFO
            Console.WriteLine("\n*** Les Queue<> ***");
            Console.WriteLine("Avec les Type int :");
            Queue<int> file = new Queue<int>();
            file.Enqueue(1);
            file.Enqueue(2);
            file.Enqueue(3);
            file.Enqueue(4);
            int valeur = file.Dequeue();
            AfficherChiffre(valeur);
            valeur = file.Dequeue();
            AfficherChiffre(valeur);
            valeur = file.Dequeue();
            AfficherChiffre(valeur);
            valeur = file.Dequeue();
            AfficherChiffre(valeur);
            #endregion

            #region Les Piles<> LIFO
            Console.WriteLine("\n*** Les Piles ***");
            Console.WriteLine("Pile de Type int :");
            Pile<int> pileEntier = new Pile<int>(3);
            pileEntier.Empiler(1);
            pileEntier.Empiler(25);
            pileEntier.Empiler(45);
            pileEntier.Empiler(55);
            Console.WriteLine("L'élément en place 1 de la pile est : {0}",pileEntier.Get(0));
            Console.WriteLine("L'élément en place 2 de la pile est : {0}",pileEntier.Get(1));
            Console.WriteLine("L'élément en place 3 de la pile est : {0}",pileEntier.Get(2));
            pileEntier.Depiler();
            Console.WriteLine("\nL'élément en place 3 de la ple est : {0}", pileEntier.Get(2));

            
            Console.WriteLine("Pile de Type Voiture :");
            Pile<Voiture> pileVoiture = new Pile<Voiture>(3);
            pileVoiture.Empiler(new Voiture("Ceed", "Verte", 30, 800));
            pileVoiture.Empiler(new Voiture("kuga", "rouge", 45, 900));
            pileVoiture.Empiler(new Voiture("Clio", "noir", 50, 800));
            Console.WriteLine("L'élément en place 1 de la pile est : {0}", pileVoiture.Get(0));
            Console.WriteLine("L'élément en place 2 de la pile est : {0}", pileVoiture.Get(1));
            Console.WriteLine("L'élément en place 3 de la pile est : {0}", pileVoiture.Get(2));
            pileVoiture.Depiler();
            Console.Write("L'élément en place 3 de la pile est : ");
            Console.WriteLine((pileVoiture.Get(2)!=null)? pileVoiture.Get(2).ToString(): "Null\n");
            #endregion

            #region Les Dictionnaires
            Console.WriteLine("\n*** Les Dictionnaires ***");
            Dictionary<string, Personne> annuaire = new Dictionary<string, Personne>();
            annuaire.Add("06 06 06 06 06", new Personne { Prenom = "Nicolas" });
            annuaire.Add("07 07 07 07 07", new Personne { Prenom = "Jeanne" });
            Personne p = annuaire["06 06 06 06 06"];
            Console.WriteLine(p.Prenom);
            #endregion

            #region Les List<>
            Console.WriteLine("\n*** Les List<> ***");
            Console.WriteLine("Les types int :");
            List<int> listeEntiers = new List<int>();
            listeEntiers.Add(10);
            listeEntiers.Add(20);
            listeEntiers.Add(30);
            Console.WriteLine("La liste contient {0} entiers.", listeEntiers.Count);
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Affichage du contenu de la liste");
            foreach (int i in listeEntiers)
            {
                Console.WriteLine(i);
                //listeEntiers.FindIndex(i);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Les types Voiture :");
            List<Voiture> listVoiture = new List<Voiture>();
            listVoiture.Add(new Voiture("Ceed", "Verte", 30, 800));
            listVoiture.Add(new Voiture("kuga", "rouge", 45, 900));
            foreach (Voiture v in listVoiture)
            {
                Console.WriteLine(v);                
            }

            #endregion
        }
        static void AfficherChiffre(int i)
        {
            Console.WriteLine("Le chiffre est : {0}", i);
        }
    }
}
