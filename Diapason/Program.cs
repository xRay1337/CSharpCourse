using System;
using System.Text;

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

            Range range2 = new Range(1, 6);
            Range range3 = new Range(5, 8);

            Console.WriteLine("Объединение интервалов {0} и {1} возвращает {2}", range1, range2, PrintRangeArray(range1.GetUnion(range2)));
            Console.WriteLine("Объединение интервалов {0} и {1} возвращает {2}", range1, range3, PrintRangeArray(range1.GetUnion(range3)));

            Range range4 = range2.GetIntersection(range3);
            Console.WriteLine("Пересечениие интервалов {0} и {1} возвращает интервал {2}", range2, range3, range4);

            Range range5 = new Range(0, 5);
            Range range6 = new Range(4, 9);
            Console.WriteLine("Разность интервалов {0} и {1} возвращает {2}", range5, range6, PrintRangeArray(range5.GetExcept(range6)));

            Range range7 = new Range(0, 5);
            Range range8 = new Range(6, 9);
            Console.WriteLine("Разность интервалов {0} и {1} возвращает {2}", range7, range8, PrintRangeArray(range7.GetExcept(range8)));

            Console.ReadKey();
        }

        public static string PrintRangeArray(Range[] ranges)
        {
            StringBuilder resultString = new StringBuilder("[");

            foreach (var e in ranges)
            {
                resultString.Append(e + ", ");
            }

            return resultString.Remove(resultString.Length - 2, 2).Append("]").ToString();
        }
    }
}
