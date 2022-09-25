using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть число: ");

            int Number = Convert.ToInt32(Console.ReadLine());

            int Sum = 0;

            if (Number.ToString().Length == 3)
            {
                for (int i = Number; i > 0; Sum += i % 10, i /= 10) ;

                if (Sum % 2 == 0)
                {
                    Console.WriteLine($"{Sum}: Сума чисел парна");
                }
                else
                {
                    Console.WriteLine($"{Sum}: Сума чисел не парна");
                }
            }
            else
            {
                Console.WriteLine("Помилка, введіть трицифрове число");
            }
        }
    }
}