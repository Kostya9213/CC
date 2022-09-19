using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNamespace
{
    class MyClass
    {
        static void Main(string[] args)
        {
            int nk, nn;

            Console.Write("Введіть початковий елемент рядку: nn = ");
            string strnn = Console.ReadLine();
            nn = Int32.Parse(strnn);

            Console.Write("Введіть межу ряду: nk = ");
            string strnk = Console.ReadLine();
            nk = Int32.Parse(strnk);

            if (nn > nk || nn < 0)
            {
                Console.WriteLine("Введено некоректні значення!");
                Console.Write("Введіть початок ряду = ");
                strnn = Console.ReadLine();
                nn = Int32.Parse(strnn);
            }
            double Prod = 1;

            for (double k = nn; k < nk; k++)
            {
                Prod *= (Math.Pow(k, 2)-((Math.Pow(-1,k*k + 1) * 2*k -1)))/((Math.Pow(k, 2) + 2));
            }

            Console.WriteLine("Сума числового ряду = " + Prod);
            Console.Read();
        }
    }
}