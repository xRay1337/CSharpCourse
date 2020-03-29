using System;
using Vectors;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(5, 5);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(matrix[i]);
            }

            Console.WriteLine();

            Matrix matrixCopy = new Matrix(matrix);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(matrixCopy[i]);
            }

            double[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Matrix matrixArr = new Matrix(arr);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(matrixArr[i]);
            }

            Console.ReadKey();
        }
    }
}
