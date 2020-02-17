using System;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(-1.5, 2);

            Console.WriteLine("Длина интервала равна {0}", range1.GetLength());
            Console.WriteLine("Число {0:f1} входит в инервал: {1}", 6.1, range1.IsInside(6.1));
            Console.WriteLine("Число {0:f1} входит в инервал: {1}", 6.0, range1.IsInside(6.0));
            Console.WriteLine("Число {0:f1} входит в инервал: {1}", 5.9, range1.IsInside(5.9));

            Range range2 = new Range(2, 6);
            Range range3 = new Range(5, 8);

            Console.WriteLine("Объединение интервалов {0} и {1} возвращают {2} интервал {3}.", range1, range2, range1.GetUnion(range2).Length, range1.GetUnion(range2)[0]);
            Console.WriteLine("Объединение интервалов {0} и {1} возвращают {2} интервала: {3} и {4}.", range1, range3, range1.GetUnion(range3).Length, range1.GetUnion(range3)[0], range1.GetUnion(range3)[1]);

            Range range4 = range2.GetIntersection(range3);
            Console.WriteLine("Пересечениие интервалов {0} и {1} возвращают интервал {2}.", range2, range3, range4);

            Range range5 = new Range(0, 5);
            Range range6 = new Range(4, 9);
            Console.WriteLine("Разность интервалов {0} и {1} возвращают интервал {2}.", range5, range6, range5.GetExcept(range6)[0]);

            Range range7 = new Range(0, 5);
            Range range8 = new Range(6, 9);
            Console.WriteLine("Разность интервалов {0} и {1} возвращают {2} интервала: {3} и {4}.", range7, range8, range7.GetExcept(range8).Length, range7.GetExcept(range8)[0], range7.GetExcept(range8)[1]);

            Console.ReadKey();
        }
    }
}
