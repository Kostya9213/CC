using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            double I;
            double U;
            double R;

            while (true)
            {
                Console.Write("Введіть напругу. U = ");
                string strU = Console.ReadLine();
                try
                {
                    U = double.Parse(strU);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Введіть опір. R = ");
                string strR = Console.ReadLine();
                try
                {
                    R = double.Parse(strR);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                break;
            }
            if (R > 0)
            {
                I = U / R;
                Console.WriteLine("Сила струму = , I = {0:n2}.R = {1}", I, R);
            }
            else
            {
                Console.WriteLine("error / try again");
            }
            Console.ReadLine();
        }
    }
}