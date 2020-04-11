using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person("Vitaliy", 30),
                new Person("Oksana", 28),
                new Person("Sonya", 8),
                new Person("Alex", 0),
                new Person("Andrey", 58),
                new Person("Irina", 55),
                new Person("Vitaliy", 28)
            };

            Console.WriteLine("Исходный список:");
            foreach (var e in persons)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            var uniqueNamesList = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            var names = string.Join(", ", uniqueNamesList);
            Console.WriteLine("Имена: {0}.", names);
            Console.WriteLine();

            var averageAgeOfMinors = persons
                .Where(p => p.Age < 18)
                .Average(p => p.Age);

            Console.WriteLine("Средний возраст до 18 = {0}.", averageAgeOfMinors);
            Console.WriteLine();

            var personsByNames = persons
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Average(a => a.Age));

            foreach (var e in personsByNames)
            {
                Console.WriteLine(e.Key + " " + e.Value);
            }

            Console.WriteLine();

            var personsByAge = persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .ToList();

            foreach (var e in personsByAge)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}