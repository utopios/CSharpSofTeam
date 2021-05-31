using System;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boxing
            int a = 15;
            double d =25.025;
            object b = a;

            int[] tabInt = new int[] { a };
            
            object[] tabObject = new object[2];
            tabObject[0] = a;
            tabObject[1] = b;

            // Unboxing
            b = 25;
            int c = (int)tabObject[0];


            Console.WriteLine(c);
        }
    }
}
