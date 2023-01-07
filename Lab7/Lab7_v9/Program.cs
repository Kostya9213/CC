using System;
using System.Collections.Generic;

namespace ListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            list.Add(2);
            list.Add(1);

            foreach (int num in list)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }

            list.RemoveAt(0);
            list.RemoveAt(0);

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
