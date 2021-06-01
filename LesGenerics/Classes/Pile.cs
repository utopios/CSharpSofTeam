using System;
using System.Collections.Generic;
using System.Text;

namespace LesGenerics.Classes
{
    class Pile<T>
    {
        T[] elements;
        int taille;
        int compteur = 0;

        public Pile(int i)
        {
            taille = i;
            elements = new T[taille];
        }

        public void Empiler(T element)
        {
            if (compteur <taille)
            {
                elements[compteur] = element;
                compteur++;
            }
            else
            {
                Console.WriteLine("La pile est pleine...");
            }
        }

        public void Depiler()
        {
            if (compteur>0)
            {
                Console.WriteLine("Je dépile le dernier élément...");
                elements[compteur - 1] = default(T);
                compteur--;
            }
            else
            {
                Console.WriteLine("Veuillez inserer un élément dans la pile...");
            }
        }

        public T Get(int index)
        {
            return elements[index];
        }
    }
}
