using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kk
{
    class Program
    {
        static void Main(string[] args)
        {
            int z, x, v;
            Console.WriteLine("Введите первое число:");
            int.TryParse(Console.ReadLine(), out z);
            Console.WriteLine("Введите второе число:");
            int.TryParse(Console.ReadLine(), out v);
            Console.WriteLine("Введите третье число:");
            int.TryParse(Console.ReadLine(), out x);
            if (z > x)
            {
                if (z > v)
                {
                    Console.WriteLine("Максимальное число:" + z);
                }
                else
                {
                    Console.WriteLine("Максимальное число:" + v);
                }
            }
            else
            {
                if (x > v)
                {
                    Console.WriteLine("Максимальное число:" + x);
                }
                else
                {
                    Console.WriteLine("Максимальное число:"+ v);
                }
            }
        }
    }
}
