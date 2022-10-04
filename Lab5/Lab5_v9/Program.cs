using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = 5;
                int y = 10;
                int[,] matrix = new int[x, y];
                Random RandomNumber = new Random();
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        matrix[i, j] = RandomNumber.Next(-9, 9);
                    }
                }
                Console.WriteLine(showMatrix(matrix));
                Console.WriteLine("Номер первой строки, содержащей равное количество положительных и отрицательных элементов {0}", firstLine(matrix));
                Console.WriteLine("Номер последней строки, содержащей равное количество положительных и отрицательных элементов {0}", lastLine(matrix));
                Console.WriteLine("Номер первого столбца, содержащего равное количество положительных и отрицательных элементов {0}", firstColumn(matrix));
                Console.WriteLine("Номер последнего столбца, содержащего равное количество положительных и отрицательных элементов {0}", lastColumn(matrix));

            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        private static int lastColumn(int[,] matrix)
        {
            for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
            {
                int negativeNum = 0;
                int positiveNum = 0;
                for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                {
                    if (matrix[j, i] < 0)
                    {
                        negativeNum++;
                    }
                    if (matrix[j, i] > 0)
                    {
                        positiveNum++;
                    }
                }
                if (negativeNum == positiveNum)
                    return i + 1;
            }
            return 0;
        }

        private static int firstColumn(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int negativeNum = 0;
                int positiveNum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        negativeNum++;
                    }
                    if (matrix[j, i] > 0)
                    {
                        positiveNum++;
                    }
                }
                if (negativeNum == positiveNum)
                    return i + 1;
            }
            return 0;
        }

        private static int lastLine(int[,] matrix)
        {
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                int negativeNum = 0;
                int positiveNum = 0;
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        negativeNum++;
                    }
                    if (matrix[i, j] > 0)
                    {
                        positiveNum++;
                    }
                }
                if (negativeNum == positiveNum)
                    return i + 1;
            }
            return 0;
        }

        private static int firstLine(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int negativeNum = 0;
                int positiveNum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negativeNum++;
                    }
                    if (matrix[i, j] > 0)
                    {
                        positiveNum++;
                    }
                }
                if (negativeNum == positiveNum)
                    return i + 1;
            }
            return 0;
        }

        private static string showMatrix(int[,] matrix)
        {
            string output = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output += string.Format("{0}\t", matrix[i, j]);
                }
                output += "\n";
            }
            return string.Format("Matrix: \n{0}", output);
        }
    }
}