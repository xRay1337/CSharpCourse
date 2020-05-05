using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "hello";
            StringBuilder stringBuilder1 = new StringBuilder("hello");
            StringBuilder stringBuilder2 = new StringBuilder("hello");

            //Console.WriteLine(str == stringBuilder1);
            Console.WriteLine(str.Equals(stringBuilder1));

            //http://Google.ru

            Console.WriteLine(stringBuilder1.Equals(stringBuilder2));

            Console.WriteLine((double)0.1f);

            Console.ReadKey();
        }
    }
}
