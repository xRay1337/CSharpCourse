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

            Console.WriteLine();

            double[,] arr = { { 2, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //double[,] arr = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

            Matrix matrixArr = new Matrix(arr);

            for (int i = 0; i < matrixArr.ColumnsCount; i++)
            {
                Console.WriteLine(matrixArr[i]);
            }

            Console.WriteLine("Столбцов " + matrixArr.ColumnsCount);
            Console.WriteLine("Строк " + matrixArr.RowsCount);

            Console.WriteLine(matrixArr);

            //matrixArr.Transpose();

            Console.WriteLine(matrixArr.GetVectorColumn(0));
            Console.WriteLine(matrixArr.GetVectorRow(0));

            //matrixArr.Multiply(2);

            //Console.WriteLine(matrixArr);

            double det = matrixArr.GetDeterminant();

            Console.WriteLine(det);
            Console.ReadKey();
        }
    }
}
