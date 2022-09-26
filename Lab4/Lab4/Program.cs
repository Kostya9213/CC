using System;
namespace Lab4_v9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] item = test(new[] { 1, 3, 7, 11, 32 });
            Console.Write("New array: ");
            foreach (var i in item)
            {
                Console.Write(i.ToString() + " ");
            }
        }
        static int[] test(int[] numbers)
        {
            int size = numbers.Length;
            int[] shiftNums = new int[size];

            for (int i = 0; i < size; i++)
            {
                shiftNums[i] = numbers[(i + 1) % size];
            }
            return shiftNums;
        }
    }
}