using System;
using System.Text;

namespace Vectors
{
    class Vector
    {
        private double[] matrix;

        public Vector(int size)
        {
            if (size > 0)
            {
                matrix = new double[size];
            }
            else
            {
                throw new Exception("Need a positive number.");
            }
        }

        public Vector(Vector vector)
        {
            matrix = new double[vector.matrix.Length];
            Array.Copy(vector.matrix, 0, matrix, 0, vector.matrix.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length > 0)
            {
                int arrayLength = array.Length;
                matrix = new double[arrayLength];
                Array.Copy(array, 0, matrix, 0, arrayLength);
            }
            else
            {
                throw new Exception("Need a positive array length.");
            }
        }

        public Vector(int size, double[] array)
        {
            if (size > 0 && size >= array.Length)
            {
                matrix = new double[size];
                array.CopyTo(matrix, 0);
            }
            else
            {
                throw new Exception("Need a positive size or array length.");
            }
        }

        public int GetSize()
        {
            return matrix.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{ ").Append(string.Join(", ", matrix)).Append(" }");
            return stringBuilder.ToString();
        }

        public Vector Add(Vector vector)
        {
            int maxLength = Math.Max(matrix.Length, vector.matrix.Length);

            double[] tempMatrix = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                double operand1 = 0;
                double operand2 = 0;

                if (i < matrix.Length)
                {
                    operand1 = matrix[i];
                }

                if (i < vector.matrix.Length)
                {
                    operand2 = vector.matrix[i];
                }

                tempMatrix[i] = operand1 + operand2;
            }

            matrix = tempMatrix;

            return this;
        }

        public Vector Subtract(Vector vector)
        {
            int maxLength = Math.Max(matrix.Length, vector.matrix.Length);

            double[] tempMatrix = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                double operand1 = 0;
                double operand2 = 0;

                if (i < matrix.Length)
                {
                    operand1 = matrix[i];
                }

                if (i < vector.matrix.Length)
                {
                    operand2 = vector.matrix[i];
                }

                tempMatrix[i] = operand1 - operand2;
            }

            matrix = tempMatrix;

            return this;
        }

        public Vector Multiply(int scalar)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] *= scalar;
            }

            return this;
        }

        public Vector Reverse()
        {
            Multiply(-1);

            return this;
        }

        public double GetLength()
        {
            double squareSum = 0;

            foreach (var e in matrix)
            {
                squareSum += Math.Pow(e, 2);
            }

            return Math.Sqrt(squareSum);
        }

        public double GetElement(int index)
        {
            return matrix[index];
        }

        public Vector SetElement(int index, double element)
        {
            matrix[index] = element;

            return this;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector v = (Vector)obj;

            if (matrix.Length != v.matrix.Length)
            {
                return false;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] != v.matrix[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;

            hash = prime * hash + matrix.GetHashCode();

            return hash;
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return vector1.Add(vector2);
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            return vector1.Subtract(vector2);
        }

        public static double Multiply(Vector vector1, Vector vector2)
        {
            double acc = 0;

            for (int i = 0; i < vector1.matrix.Length; i++)
            {
                acc += vector1.matrix[i] * vector2.matrix[i];
            }

            return acc;
        }
    }
}