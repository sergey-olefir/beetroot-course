using System;

namespace Lesson20.Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "This is my string";
            Console.WriteLine(WordCount(str1));
            Console.WriteLine(str1.WordCount());

            str1.WordCount();
            str1.WordCount();

            Console.WriteLine("sfsdfsdf".ToBool());
            Console.WriteLine("true".ToBool());
        }

        public static int WordCount(string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}