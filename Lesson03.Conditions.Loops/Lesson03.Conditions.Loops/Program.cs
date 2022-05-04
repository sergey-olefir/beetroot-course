using System;

namespace Lesson03.Conditions.Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 6;

            if (a < b)
            {
                Console.WriteLine($"{a} is less than {b}");
            }
            else
            {
                Console.WriteLine($"{a} is more than {b}");
            }

            const int number = 20;
            string s = a > number
                ? $"{a} is more than {number}"
                : $"{a} is less than {number}";

            int c = a < b
                ? a + b
                : a - b;

            Console.WriteLine(s);
            Console.WriteLine(c);

            switch (a)
            {
                case 5:
                    Console.WriteLine($"a is 5");
                    break;
                case 6:sldfhdsh fkshdk hdkfhk fjdh gkdfh
                    Console.WriteLine($"a is 6");
                    break;
                case 7:
                    Console.WriteLine($"a is 7");
                    break;
                default:
                    Console.WriteLine("a is some");
                    break;
            }

            var dayOfWeek = 2;
            switch (dayOfWeek)
            {
                case 1:
                    Console.WriteLine($"Today is Sunday");
                    break;
                case 2:
                    Console.WriteLine($"Today is Monday");
                    break;
                case 7:
                    Console.WriteLine($"Today is Saturday");
                    break;
                default:
                    Console.WriteLine("Today is another day");
                    break;
            }

            const int N = 10;
            int sum = 0;
            int i = 0;

            for (i = 0; i < N; i++)
            {
                sum += i;
            }

            Console.WriteLine($"Sum of {N} is {sum}");

            i = 0;
            sum = 0;

            while (i != N)
            {
                sum += i++;
            }

            Console.WriteLine($"Sum of {N} is {sum}");

            i = 0;
            sum = 0;

            do
            {
                sum += i++;
            } while (i < N);

            Console.WriteLine($"Sum of {N} is {sum}");

            i = 0;
            sum = 0;

            for (; i < N; i++)
            {
                sum += (i % 2 == 0)
                    ? i
                    : 0;
            }

            Console.WriteLine(sum);

            i = 0;
            sum = 0;

            for (; i < N; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }
                sum += i;
            }

            Console.WriteLine(sum);

            i = 0;
            sum = 0;

            while (true)
            {
                sum += i % 2 == 0
                    ? i
                    : 0;

                if (++i >= N)
                {
                    break;
                }
            }

            Console.WriteLine(sum);

            string message = Console.ReadLine();

            if (int.TryParse(message, out int digit))
            {
                Console.WriteLine(digit);
            }
            else
            {
                Console.WriteLine("Input is incorrent");
            }

            // a i b - вводимо з клавіатури
            // v - вводомо з клавіатури
            // 1 - додавання
            // 2 - віднімення
            // 3 - множення
            // 4 - ділення
            // все інше - виходимо з програми
            Environment.Exit(0);
            Console.ReadKey();
        }
    }
}
