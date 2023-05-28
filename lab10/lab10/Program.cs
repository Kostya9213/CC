using System;

namespace Lab10
{
    static class Extensions
    {
        public static int Reverse(this int number)
        {
            int reversedNumber = 0;

            while (number != 0)
            {
                int remainder = number % 10;
                reversedNumber = reversedNumber * 10 + remainder;
                number /= 10;
            }

            return reversedNumber;
        }

        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static double Reverse(this double number)
        {
            string numberString = number.ToString();
            char[] charArray = numberString.ToCharArray();
            Array.Reverse(charArray);
            string reversedNumberString = new string(charArray);
            return double.Parse(reversedNumberString);
        }

        public static string ReverseAfterMagic(this string str)
        {
            string[] parts = str.Split(',');

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Reverse();
            }

            return string.Join(",", parts);
        }

        public static void ReverseArray(ref int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;

                left++;
                right--;
            }
        }

        public static void ReverseArrayRef(ref int[] array)
        {
            Array.Reverse(array);
        }

        public static void CreateReversedArray(out int[] array)
        {
            array = new int[] { 5, 4, 3, 2, 1 };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = ReadIntFromConsole();
            int reversedNumber = Extensions.Reverse(number);
            Console.WriteLine("Reversed number: " + reversedNumber);

            string str = ReadStringFromConsole();
            string reversedString = Extensions.Reverse(str);
            Console.WriteLine("Reversed string: " + reversedString);

            double decimalNumber = ReadDoubleFromConsole();
            double reversedDecimalNumber = Extensions.Reverse(decimalNumber);
            Console.WriteLine("Reversed decimal number: " + reversedDecimalNumber);

            string magicString = ReadStringFromConsole();
            string reversedMagicString = Extensions.ReverseAfterMagic(magicString);
            Console.WriteLine("Reversed magic string: " + reversedMagicString);

            int[] array = { 1, 2, 3, 4, 5 };
            Extensions.ReverseArray(ref array);
            Console.WriteLine("Reversed array: " + string.Join(", ", array));

            int[] array2 = { 6, 7, 8, 9, 10 };
            Extensions.ReverseArrayRef(ref array2);
            Console.WriteLine("Reversed array using ref: " + string.Join(", ", array2));

            int[] array3;
            Extensions.CreateReversedArray(out array3);
            Console.WriteLine("Reversed array using out: " + string.Join(", ", array3));
        }

        public static int ReadIntFromConsole()
        {
            Console.Write("Enter an integer number: ");
            return int.Parse(Console.ReadLine());
        }

        public static string ReadStringFromConsole()
        {
            Console.Write("Enter a string: ");
            return Console.ReadLine();
        }

        public static double ReadDoubleFromConsole()
        {
            Console.Write("Enter a decimal number: ");
            return double.Parse(Console.ReadLine());
        }
    }
}
