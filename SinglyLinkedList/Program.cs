﻿using System;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> list1 = new SinglyLinkedList<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Превый элемент: {0}", list1.First);
            Console.WriteLine();

            Console.WriteLine("Последний элемент: {0}", list1.GetElement(list1.Count - 1));
            Console.WriteLine();

            Console.WriteLine("Меняем последний элемент. Старое значениие: {0}", list1.SetElement(list1.Count - 1, 6));
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Удаляем последний элемент. Старое значениие: {0}", list1.RemoveAt(list1.Count - 1));
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Вставка в начало.");
            list1.InsertFirst(0);
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Вставка в конец.");
            list1.InsertAt(list1.Count, 5);
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Удаление \"3\". Операция успешна: {0}", list1.Remove(3));
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Удаляем первый элемент. Старое значениие: {0}", list1.RemoveFirst());
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Удаляем последний элемент. Старое значениие: {0}", list1.RemoveAt(list1.Count - 1));
            Console.WriteLine("Тестовый список 1:");
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Список 1 в обратном порядке:");
            list1.Reverse();
            Console.WriteLine(list1);
            Console.WriteLine();

            Console.WriteLine("Список 2 - копия списка 1:");
            SinglyLinkedList<int> list2 = list1.Copy();
            Console.WriteLine(list2);

            Console.ReadKey();
        }
    }
}