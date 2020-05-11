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
            string s = null;

            string st = s ?? string.Empty;

            Console.WriteLine(st.Length);

            StringBuilder stringBuilder1 = new StringBuilder("hello");
            StringBuilder stringBuilder2 = new StringBuilder("hello");

            //Console.WriteLine(str == stringBuilder1);
            Console.WriteLine(str.Equals(stringBuilder1));

            //http://Google.ru

            Console.WriteLine(stringBuilder1.Equals(stringBuilder2));

            Console.WriteLine((double)0.1f);

            string str1 = null;
            string str2 = "1";

            Console.WriteLine(Equals(str1, str2));

            Console.ReadKey();
        }
    }
}
