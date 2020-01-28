using System;

namespace Vectors
{
    class Vector
    {
        private double[] vector;

        public Vector(int size)
        {
            vector = new double[size];
        }

        public Vector(Vector vector)
        {
            this.vector = vector.vector;
        }

        public Vector(double[] array)
        {
            int arrayLength = array.Length;
            vector = new double[arrayLength];
            Array.Copy(array, 0, vector, 0, arrayLength);
        }

        public Vector(int size, double[] array)
        {
            vector = new double[size];
            array.CopyTo(vector, 0);
        }

        public int GetSize()
        {
            return vector.Length;
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", vector) + " }";
        }

        public Vector Addition(Vector vector)
        {
            int vectorSize = this.vector.Length;

            for (int i = 0; i < vectorSize; i++)
            {
                double operand2 = 0;

                if (i < vector.vector.Length)
                {
                    operand2 = vector.vector[i];
                }

                this.vector[i] += operand2;
            }

            return this;
        }

        public Vector Subtraction(Vector vector)
        {
            int vectorSize = this.vector.Length;

            for (int i = 0; i < vectorSize; i++)
            {
                double operand2 = 0;

                if (i < vector.vector.Length)
                {
                    operand2 = vector.vector[i];
                }

                this.vector[i] -= operand2;
            }

            return this;
        }

        public Vector MultiplicationByScalar(int scalar)
        {
            int vectorSize = this.vector.Length;

            for (int i = 0; i < vectorSize; i++)
            {
                this.vector[i] *= scalar;
            }

            return this;
        }

        public Vector Reverse()
        {
            MultiplicationByScalar(-1);

            return this;
        }

        public double GetLength()
        {
            int vectorSize = this.vector.Length;
            double squareSum = 0;

            for (int i = 0; i < vectorSize; i++)
            {
                squareSum += Math.Pow(this.vector[i], 2);
            }

            return Math.Sqrt(squareSum);
        }

        public double GetElement(int index)
        {
            return vector[index];
        }

        public Vector SetElement(int index, double element)
        {
            vector[index] = element;

            return this;
        }

        public override bool Equals(object obj)
        {
            int vectorSize = this.vector.Length;
            Vector inputVector = obj as Vector;

            if (vectorSize != inputVector.vector.Length)
            {
                return false;
            }

            for (int i = 0; i < vectorSize; i++)
            {
                if (this.vector[i] == inputVector.vector[i])
                {
                    continue;
                }

                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + (int)this.GetLength();
        }

        public static Vector Addition(Vector vector1, Vector vector2)
        {
            int vectorSize = Math.Max(vector1.vector.Length, vector2.vector.Length);
            double[] newVector = new double[vectorSize];

            for (int i = 0; i < vectorSize; i++)
            {
                double operand1 = 0;
                double operand2 = 0;

                if (i < vector1.vector.Length)
                {
                    operand1 = vector1.vector[i];
                }

                if (i < vector2.vector.Length)
                {
                    operand2 = vector2.vector[i];
                }

                newVector[i] = operand1 + operand2;
            }

            return new Vector(newVector);
        }

        public static Vector Subtraction(Vector vector1, Vector vector2)
        {
            int vectorSize = Math.Max(vector1.vector.Length, vector2.vector.Length);
            double[] newVector = new double[vectorSize];

            for (int i = 0; i < vectorSize; i++)
            {
                double operand1 = 0;
                double operand2 = 0;

                if (i < vector1.vector.Length)
                {
                    operand1 = vector1.vector[i];
                }

                if (i < vector2.vector.Length)
                {
                    operand2 = vector2.vector[i];
                }

                newVector[i] = operand1 - operand2;
            }

            return new Vector(newVector);
        }

        public static double ScalarMultiplication(Vector vector1, Vector vector2)
        {
            int vectorSize = vector1.vector.Length;
            double result = 0;

            for (int i = 0; i < vectorSize; i++)
            {
                double operand1 = 0;
                double operand2 = 0;

                if (i < vector1.vector.Length)
                {
                    operand1 = vector1.vector[i];
                }

                if (i < vector2.vector.Length)
                {
                    operand2 = vector2.vector[i];
                }

                result += operand1 * operand2;
            }

            return result;
        }
    }
}