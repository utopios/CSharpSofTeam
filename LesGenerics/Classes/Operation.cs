using System;
using System.Collections.Generic;
using System.Text;

namespace LesGenerics.Classes
{
    class Operation<T>
    {
        public string EstEquivalent(T a , T b)
        {
            if (a.Equals(b))
            {
                return "C'est équivalent";
            }
            else
            {
                return "Ce n'est pas équivalent";
            }
        }
    }
}
