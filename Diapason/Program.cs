using System;

namespace Diapason
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range = new Range(6, -1.5);

            Console.WriteLine("Длина интервала равна {0}", range.GetLength());
            Console.WriteLine("Число 6.1 входит в инервал: {0}", range.IsInside(6.1));
            Console.WriteLine("Число 6.0 входит в инервал: {0}", range.IsInside(6.0));
            Console.WriteLine("Число 5.9 входит в инервал: {0}", range.IsInside(5.9));

            Console.ReadKey();
        }
    }
}
