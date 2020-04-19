using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var x;
            Console.WriteLine(x);

            Console.WriteLine("Чтение из файла:");

            try
            {
                List<string> textFromFile = ReadFile("..\\..\\text.txt");

                foreach (var e in textFromFile)
                {
                    Console.WriteLine(e);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл не найден.");
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("Удалить все четные числа:");

            List<int> numbers = new List<int> { 1, 1, 2, 3, 4, 5, 5 };

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            foreach (var e in numbers)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.WriteLine("Удалить дубли:");

            List<int> uniqueNumbers = RemoveDuplicates(numbers);

            foreach (var e in uniqueNumbers)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        private static List<int> RemoveDuplicates(List<int> numbers)
        {
            List<int> result = new List<int>(numbers.Capacity);

            foreach (var e in numbers)
            {
                if (!result.Contains(e))
                {
                    result.Add(e);
                }
            }

            return result;
        }

        private static List<string> ReadFile(string path)
        {
            List<string> result = new List<string>();

            using (StreamReader streamReader = new StreamReader(path))
            {
                string currentString;

                while ((currentString = streamReader.ReadLine()) != null)
                {
                    result.Add(currentString);
                }
            }

            return result;
        }
    }
}