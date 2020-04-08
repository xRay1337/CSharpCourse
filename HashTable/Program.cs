using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> vs = new List<int>();
            vs.CopyTo()
            Console.WriteLine("Создаём таблицу.");
            HashTable<string> hashTable = new HashTable<string> { "A", "B", "C" };
            Console.WriteLine("Исходная таблица: " + hashTable);
            Console.WriteLine("Размер = {0}", hashTable.Count);
            Console.WriteLine();

            Console.WriteLine("Добавляем дубликат.");
            hashTable.Add("C");
            Console.WriteLine("Исходная таблица: " + hashTable);
            Console.WriteLine("Размер = {0}", hashTable.Count);
            Console.WriteLine();

            Console.WriteLine("Добавляем оригинальное значение.");
            hashTable.Add("D");
            Console.WriteLine("Исходная таблица: " + hashTable);
            Console.WriteLine("Размер = {0}", hashTable.Count);
            Console.WriteLine();

            Console.WriteLine("Удаляем D.");
            hashTable.Remove("D");
            Console.WriteLine("Исходная таблица: " + hashTable);
            Console.WriteLine("Размер = {0}", hashTable.Count);
            Console.WriteLine();

            Console.WriteLine("Таблица содержит D?");
            Console.WriteLine(hashTable.Contains("D") ? "Да" : "Нет");
            Console.WriteLine();

            Console.WriteLine("Очищаем таблицу.");
            hashTable.Clear();
            Console.WriteLine("Исходная таблица: " + hashTable);
            Console.WriteLine("Размер = {0}", hashTable.Count);
            Console.WriteLine();

            HashTable<int> hashTable1 = new HashTable<int> { 1, 2, 3, 2 };
            HashTable<int> hashTable2 = new HashTable<int> { 1, 2, 3, 2 };
            Console.WriteLine(hashTable1.Equals(hashTable2));

            Console.ReadKey();
        }
    }
}
