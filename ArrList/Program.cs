using System;
using System.Collections.Generic;

namespace ArrList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrList<int> arrList1 = new ArrList<int>();

            int[] array = new int[30];

            for (int i = 1; i <= 20; i++)
            {
                arrList1.Add(i);
            }

            Console.WriteLine("Лист после инициализации:");
            Console.WriteLine(arrList1);
            Console.WriteLine();

            arrList1.RemoveAt(5);
            Console.WriteLine("Удаляем 5й элемент:");
            Console.WriteLine(arrList1);
            Console.WriteLine();

            arrList1.Remove(5);
            Console.WriteLine("Удаляем элемент с значениием 5:");
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Есть элемент с значениием 5? {0}", arrList1.Contains(5));
            Console.WriteLine();

            Console.WriteLine("Индекс элемента со значениием 10 = {0}", arrList1.IndexOf(10));
            Console.WriteLine();

            arrList1.CopyTo(array, 6);
            Console.WriteLine("Копирование в массив из 30 элементов:");
            Console.WriteLine("[ " + string.Join(", ", array) + " ]");
            Console.WriteLine();

            arrList1.Insert(0, 20);
            Console.WriteLine("Вставка числа 20 в начало:");
            Console.WriteLine(arrList1);
            Console.WriteLine();

            ArrList<int> arrList2 = new ArrList<int>() { 1, 2, 3 };
            ArrList<int> arrList3 = new ArrList<int>() { 1, 2, 3 };

            Console.WriteLine("arrList2 эквивалентен arrList1? {0}", arrList2.Equals(arrList1));
            Console.WriteLine("arrList2 эквивалентен arrList3? {0}", arrList2.Equals(arrList3));
            Console.WriteLine();

            Console.WriteLine("Хэш для arrList1 = {0}", arrList1.GetHashCode());
            Console.WriteLine("Хэш для arrList2 = {0}", arrList2.GetHashCode());
            Console.WriteLine("Хэш для arrList3 = {0}", arrList3.GetHashCode());

            Console.ReadKey();
        }
    }
}
