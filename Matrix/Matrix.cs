using System;
using System.Text;
using Vectors;

namespace Matrix
{
    class Matrix
    {
        private Vector[] matrix;
        private int rowsCount;
        private int columnsCount;

        public int RowsCount { get => rowsCount; }

        public int ColumnsCount { get => columnsCount; }

        public Vector this[int index]
        {
            get
            {
                CheckPositiveArgument(index, rowsCount);

                return matrix[index];
            }
            set
            {
                CheckPositiveArgument(index, rowsCount);

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

            rowsCount = rows;
            columnsCount = columns;

            matrix = new Vector[rows];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new Vector(columns);
            }
        }

        public Matrix(Matrix matrix) : this(matrix.ColumnsCount, matrix.RowsCount) // конструктор копирования
        {
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                this.matrix[i] = new Vector(matrix[i]);
            }
        }

        public Matrix(double[,] array) : this(array.Length / ((array.GetUpperBound(0) + 1)), array.GetUpperBound(0) + 1)// из двумерного массива(в C# double[,])
        {
            rowsCount = array.GetUpperBound(0) + 1;
            columnsCount = array.Length / rowsCount;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
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

        //        Методы:

        //+a.Получение размеров матрицы

        //+b.Получение и задание вектора-строки по индексу

        //+c.Получение вектора-столбца по индексу

        //+d.Транспонирование матрицы

        //+e.Умножение на скаляр

        //+f.Вычисление определителя матрицы

        //+g.toString определить так, чтобы результат получался в таком виде: { { 1, 2 }, { 2, 3 } }

        //h.умножение матрицы на вектор

        //i.Сложение матриц

        //j.Вычитание матриц

        private void CheckPositiveArgument(int argument, int maxValue)
        {
            if (argument < 0)
            {
                throw new ArgumentException("Argument must be positive.", nameof(argument));
            }

            if (argument > maxValue)
            {
                throw new ArgumentException("Argument is greater than the allowed value.", nameof(argument));
            }
        }

        public Vector GetVectorColumn(int columnNumber)
        {
            CheckPositiveArgument(columnNumber, columnsCount - 1);

            Vector result = new Vector(rowsCount);

            for (int i = 0; i < rowsCount; i++)
            {
                result[i] = matrix[i][columnNumber];
            }

            return result;
        }

        public Vector GetVectorRow(int rowNumber)
        {
            CheckPositiveArgument(rowNumber, rowsCount - 1);

            return new Vector(matrix[rowNumber]);
        }

        public void Transpose()
        {
            Vector[] newMatrix = new Vector[columnsCount];

            for (int i = 0; i < columnsCount; i++)
            {
                newMatrix[i] = new Vector(rowsCount);

                for (int j = 0; j < rowsCount; j++)
                {
                    newMatrix[i][j] = matrix[j][i];
                }
            }

            int temp = columnsCount;
            columnsCount = rowsCount;
            rowsCount = temp;

            matrix = newMatrix;
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i].Multiply(scalar);
            }
        }

        public double GetDeterminant()//double[,] matrix
        {
            if (rowsCount != columnsCount)
            {
                throw new InvalidOperationException("Non-square matrix.");
            }

            int matrixSize = rowsCount;

            if (matrixSize == 1)
            {
                return matrix[0][0];
            }

            if (matrixSize == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }

            double determinant = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                double[,] algebraicAddition = new double[matrixSize - 1, matrixSize - 1];

                for (int j = 1; j < matrixSize; j++)
                {
                    for (int k = 0, index = 0; k < matrixSize; k++, index++)
                    {
                        if (k == i)
                        {
                            index--;
                            continue;
                        }

                        algebraicAddition[j - 1, index] = matrix[j][k];
                    }
                }

                Matrix algebraicAdditio = new Matrix(algebraicAddition);

                determinant += (int)Math.Pow(-1, i) * matrix[0][i] * algebraicAdditio.GetDeterminant();
            }

            return determinant;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("{");

            if (RowsCount != 0)
            {
                for (int i = 0; i < RowsCount; i++)
                {
                    stringBuilder.Append(matrix[i].ToString()).Append(",");
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

            return stringBuilder.Append("}").ToString();
        }
    }
}