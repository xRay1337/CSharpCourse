using System;
using System.Linq;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1 = { 2, 3 };
            double[] arr2 = { 7, 3 };
            double[] arr3 = { 1, 2, 3 };
            double[] arr4 = { 4, 5, 6 };

            Console.WriteLine("Конструкторы:");
            Console.WriteLine();

            Vector vector1 = new Vector(5);
            Console.WriteLine("Конструктор по размеру: " + vector1);

            Vector vector2 = new Vector(vector1);
            Console.WriteLine("Конструктор копирования: " + vector2);

            Vector vector3 = new Vector(arr3);
            Console.WriteLine("Конструктор с массивом: " + vector3);

            Vector vector4 = new Vector(5, arr3);
            Console.WriteLine("Конструктор с массивом и размером 5: " + vector4);

            Console.WriteLine();
            Console.WriteLine("Нестатические методы:");
            Console.WriteLine();

            Console.WriteLine("Размерность первого вектора: {0}", vector1);

            Console.WriteLine("Сумма векторов {0} и {1} равна {2}", vector3, vector4, vector3.Add(vector4));

            Console.WriteLine("Разность векторов {0} и {1} равна {2}", vector3, vector4, vector3.Subtract(vector4));

            Console.WriteLine("Умножение вектора {0} на скаляр {1} равно {2}", vector3, 5, vector3.Multiply(5));

            Console.WriteLine("Разворот вектора {0} равен {1}", vector3, vector3.Reverse());

            Console.WriteLine("Длина вектора {0} равна {1:f2}", vector3, vector3.GetLength());

            Console.WriteLine("X вектора {0} равен {1}", vector3, vector3.GetElement(0));

            Console.WriteLine("Меняем X вектора {0} на {1}, сейчас вектор выглядит так: {2}", vector3, 25, vector3.SetElement(0, 25));

            Console.WriteLine("Метод Equals для {0} и {1} возвращает: {2}", vector3, vector4, vector3.Equals(null));

            Console.WriteLine("Хэш-кодом для вектора {0} является: {1}", vector3, vector3.GetHashCode());

            Console.WriteLine();
            Console.WriteLine("Статические методы:");
            Console.WriteLine();

            Console.WriteLine("Сумма векторов {0} и {1} равна {2}", vector3, vector4, Vector.Add(vector3, vector4));

            Console.WriteLine("Разность векторов {0} и {1} равна {2}", vector3, vector4, Vector.Subtract(vector3, vector4));

            Console.WriteLine("Скалярное произведение векторов {0} и {1} равно {2}", vector3, vector4, Vector.MultiplyByScalar(vector3, vector4));


            Vector vector5 = new Vector(arr1);


            //Console.WriteLine(vector1.GetLength());
            //Console.WriteLine(vector1.Equals(vector4));

            Console.ReadKey();
        }
    }
}