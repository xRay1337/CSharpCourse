using System;
using System.Text;

namespace Vectors
{
    class Vector
    {
        private double[] vectorCoordinates;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Need a positive number.", "size");
            }

            vectorCoordinates = new double[size];
        }

        public Vector(Vector vector)
        {
            vectorCoordinates = new double[vector.vectorCoordinates.Length];
            Array.Copy(vector.vectorCoordinates, 0, vectorCoordinates, 0, vector.vectorCoordinates.Length);
        }

        public Vector(double[] array)
        {
            if (array.Length <= 0)
            {
                throw new ArgumentException("Need a positive array size.");
            }

            vectorCoordinates = new double[array.Length];
            Array.Copy(array, 0, vectorCoordinates, 0, array.Length);

        }

        public Vector(int size, double[] array)
        {
            if (size <= 0 && array.Length == 0)
            {
                throw new ArgumentException("Need a positive size or array length.");
            }

            vectorCoordinates = new double[size];
            array.CopyTo(vectorCoordinates, 0);
        }

        public int GetSize()
        {
            return vectorCoordinates.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{ ").Append(string.Join(", ", vectorCoordinates)).Append(" }");

            return stringBuilder.ToString();
        }

        public Vector Add(Vector vector)
        {
            if (vectorCoordinates.Length < vector.vectorCoordinates.Length)
            {
                Array.Resize(ref vectorCoordinates, vector.vectorCoordinates.Length);
            }

            for (int i = 0; i < vector.vectorCoordinates.Length; i++)
            {
                vectorCoordinates[i] += vector.vectorCoordinates[i];
            }

            return this;
        }

        public Vector Subtract(Vector vector)
        {
            if (vectorCoordinates.Length < vector.vectorCoordinates.Length)
            {
                Array.Resize(ref vectorCoordinates, vector.vectorCoordinates.Length);
            }

            for (int i = 0; i < vector.vectorCoordinates.Length; i++)
            {
                vectorCoordinates[i] -= vector.vectorCoordinates[i];
            }

            return this;
        }

        public Vector Multiply(int scalar)
        {
            for (int i = 0; i < vectorCoordinates.Length; i++)
            {
                vectorCoordinates[i] *= scalar;
            }

            return this;
        }

        public Vector Reverse()
        {
            return Multiply(-1);
        }

        public double GetLength()
        {
            double squareSum = 0;

            foreach (var e in vectorCoordinates)
            {
                squareSum += Math.Pow(e, 2);
            }

            return Math.Sqrt(squareSum);
        }

        public double GetElement(int index)
        {
            return vectorCoordinates[index];
        }

        public Vector SetElement(int index, double element)
        {
            vectorCoordinates[index] = element;

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

            if (vectorCoordinates.Length != v.vectorCoordinates.Length)
            {
                return false;
            }

            for (int i = 0; i < vectorCoordinates.Length; i++)
            {
                if (vectorCoordinates[i] != v.vectorCoordinates[i])
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

            foreach (var e in vectorCoordinates)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            Vector tempVector = new Vector(vector1);

            return tempVector.Add(vector2);
        }

        public static Vector Subtract(Vector vector1, Vector vector2)
        {
            Vector tempVector = new Vector(vector1);

            return tempVector.Subtract(vector2);
        }

        public static double MultiplyByScalar(Vector vector1, Vector vector2)
        {
            double result = 0;

            for (int i = 0; i < vector1.vectorCoordinates.Length && i < vector2.vectorCoordinates.Length; i++)
            {
                result += vector1.vectorCoordinates[i] * vector2.vectorCoordinates[i];
            }

            return result;
        }
    }
}