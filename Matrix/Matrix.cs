using System;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] matrix;

        public int RowsCount
        {
            get
            {
                return matrix.Length;
            }
        }

        public int ColumnsCount
        {
            get
            {
                return matrix[0].GetSize();
            }
        }

        public Vector this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentException("Argument must be positive.", nameof(index));
                }

                return matrix[index];
            }
            set
            {
                if (index < 0)
                {
                    throw new ArgumentException("Argument must be positive.", nameof(index));
                }

                matrix[index] = value;
            }
        }

        public Matrix(int columns, int rows) // матрица нулей размера nxm
        {
            if (columns < 1)
            {
                throw new ArgumentException("Argument must be greater than 0.", nameof(columns));
            }

            if (rows < 1)
            {
                throw new ArgumentException("Argument must be greater than 0.", nameof(rows));
            }

            matrix = new Vector[columns];

            for (int i = 0; i < columns; i++)
            {
                matrix[i] = new Vector(rows);
            }
        }

        public Matrix(Matrix matrix) : this(matrix.ColumnsCount, matrix.RowsCount) // конструктор копирования
        {
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                this.matrix[i] = new Vector(matrix[i]);
            }
        }

        public Matrix(double[,] array) : this(array.GetUpperBound(0) + 1, array.Length / (array.GetUpperBound(0) + 1))// из двумерного массива(в C# double[,])
        {
            int columns = array.GetUpperBound(0) + 1;
            int rows = array.Length / columns;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = array[i, j];
                }
            }

            array.GetUpperBound(0);
        }

        public Matrix(Vector[] vectors) : this(vectors[0].GetSize(), vectors.Length) // из массива векторов-стро
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new Vector(vectors[i]);
            }
        }
    }
}
