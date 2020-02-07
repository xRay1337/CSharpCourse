using System;

namespace Diapason
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range0 = new Range(-1.5, 2);

            Console.WriteLine("Длина интервала равна {0}", range0.GetLength());
            Console.WriteLine("Число {0:f1} входит в инервал: {1}", 6.1, range0.IsInside(6.1));
            Console.WriteLine("Число {0:f1} входит в инервал: {1}", 6.0, range0.IsInside(6.0));
            Console.WriteLine("Число {0:f1} входит в инервал: {1}", 5.9, range0.IsInside(5.9));

            Range range1 = new Range(0, 5);
            Range range2 = new Range(4, 8);

            Range range3 = range1.Intersection(range2);
            Console.WriteLine("Длина интервала пересечения {0}", range3.GetLength());

            Console.WriteLine("Объединение интервалов {0} и {1} возвращают {2} интервал(а)", "range0", "range1", range0.Union(range1).Length);

            Console.WriteLine("Объединение интервалов {0} и {1} возвращают {2} интервал(а)", "range0", "range2", range0.Union(range2).Length);

            Console.WriteLine("Разность интервалов {0} и {1} возвращают {2} интервал(а)", "range0", "range1", range0.Except(range1).Length);

            Console.WriteLine("Разность интервалов {0} и {1} возвращают {2} интервал(а)", "range0", "range2", range0.Except(range2).Length);

            Console.ReadKey();
        }
    }
}
