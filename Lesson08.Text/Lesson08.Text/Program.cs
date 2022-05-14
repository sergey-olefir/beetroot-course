using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lesson08.Text
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Phone book.csv";

            string[] content = File.ReadAllLines(filePath);

            // (int a, int b) tuple;
            //
            // tuple.b = 3;
            // tuple.a = 1;
            // int c = tuple.a + tuple.b;

            foreach (var item in content)
            {
                Console.WriteLine(item);
            }

            foreach ((string name, int number) item in Deserialize(content))
            {
                Console.WriteLine($"Name is {item.name}, number is {item.number}");
            }

            var phoneBook = Deserialize(content);

            phoneBook[1].number = 101010101;

            var serializedBook = Serialize(phoneBook);
            foreach (var item in serializedBook)
            {
                Console.WriteLine(item);
            }
            
            File.WriteAllLines(filePath, serializedBook);
        }

        private static string[] Serialize((string name, int number)[] content)
        {
            var strings = new string[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                strings[i] = $"{content[i].name};{content[i].number}";
            }

            return strings;
        }

        private static (string name, int number)[] Deserialize(string[] content)
        {
            var regexp = new Regex(@"^(\w+);(\d+)$");
            var book = new (string name, int number)[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                var item = content[i];
                var match = regexp.Match(item);

                if (match.Success)
                {
                    book[i].name = match.Groups[1].Value;
                    book[i].number = int.Parse(match.Groups[2].Value);
                }
            }
            return book;
        }
    }
}