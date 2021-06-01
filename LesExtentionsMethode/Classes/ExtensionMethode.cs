using System;
using System.Collections.Generic;
using System.Text;

namespace LesExtentionsMethode.Classes
{
    static class ExtensionMethode
    {
        public static void Shuffle<T>(this List<T> liste)
        {
            Random r = new Random();
            for (int i = 0; i < liste.Count; i++)
            {
                int index = r.Next(liste.Count);
                T tmp = liste[i];
                liste[i] = liste[index];
                liste[index] = tmp;
            }
        }
    }
}
