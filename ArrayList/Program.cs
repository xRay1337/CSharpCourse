using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> arrList1 = new ArrayList<int>();

            int[] array = new int[30];


            for (int i = 1; i <= 20; i++)
            {
                arrList1.Add(i);
            }

            Console.WriteLine("Лист после инициализации:");
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Удаляем 5й элемент:");
            arrList1.RemoveAt(5);
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Удаляем элемент с значениием 5:");
            arrList1.Remove(5);
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Есть элемент с значениием 5? {0}", arrList1.Contains(5));
            Console.WriteLine();

            Console.WriteLine("Индекс элемента со значениием 10 = {0}", arrList1.IndexOf(10));
            Console.WriteLine();

            Console.WriteLine("Копирование в массив из 30 элементов:");
            arrList1.CopyTo(array, 4);
            Console.WriteLine("[ " + string.Join(", ", array) + " ]");
            Console.WriteLine();


            Console.WriteLine("Вставка числа 30 в начало:");
            arrList1.Insert(0, 30);
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Вставка числа 30 в середину по индексу {0}:", arrList1.Count / 2);
            arrList1.Insert(arrList1.Count / 2, 30);
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Вставка числа 30 в конец:");
            arrList1.Insert(arrList1.Count, 30);
            Console.WriteLine(arrList1);
            Console.WriteLine();

            ArrayList<int> arrList2 = new ArrayList<int>() { 1, 2, 3 };
            ArrayList<int> arrList3 = new ArrayList<int>() { 1, 2, 3 };

            Console.WriteLine("arrList2 эквивалентен arrList1? {0}", arrList2.Equals(arrList1));
            Console.WriteLine("arrList2 эквивалентен arrList3? {0}", arrList2.Equals(arrList3));
            Console.WriteLine();

            Console.WriteLine("Лист после очистки:");
            arrList1.Clear();
            Console.WriteLine(arrList1);
            Console.WriteLine();

            Console.WriteLine("Хэш для arrList1 = {0}", arrList1.GetHashCode());
            Console.WriteLine("Хэш для arrList2 = {0}", arrList2.GetHashCode());
            Console.WriteLine("Хэш для arrList3 = {0}", arrList3.GetHashCode());

            ArrayList<string> arrString = new ArrayList<string>();
            string str = null;
            arrString.Add(str);
            arrString.Remove(str);

            Console.WriteLine(arrString);

            Console.ReadKey();
        }
    }
}