namespace Lesson04.Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Sum(10, 20);
            Console.WriteLine(sum); //30
            Console.WriteLine(Sum(10, 20)); //30
            Console.WriteLine(Sum(10, 20, true)); //30
            Console.WriteLine(Sum(10, 20, false)); //-10

            int number1 = 4;
            int number2 = 14;

            Sum(number1, number2);
            // 11
            Console.WriteLine(IsOdd(11)); // false
            Console.WriteLine(SumNumbers(9, 10)); // false
            Console.WriteLine(SumNumbers(11, 10)); // false

            int i = 10;
            Increment(ref i); // 11
            Increment(ref i); // 12

            Console.WriteLine(i);

            if (TryDivide(100, 10, out int result))
            {
                Console.WriteLine(result);
            }

            if (!TryDivide(11, 10, out result))
            {
                Console.WriteLine(result);
            }

            Concat("10", "20"); // 10 20
            Concat("10", "20", "30"); // 10 20 30
            Concat("10", "20", "30", "40"); // 4
            Concat("10", "20", "30", "40", "50"); // 5
            Concat("10"); // 10

            Console.WriteLine(Factorial(5)); // 120
            Console.WriteLine(FactorialRecursive(5)); // 120
            Console.WriteLine(nameof(FactorialRecursive)); // FactorialRecursive

            int a = 10;
            int b = 20;
            Console.WriteLine($"{a} is less than {b}");
            Console.WriteLine($"{10} is less than {20}");

            Action<string> write = (string str) => Console.WriteLine(str);
            Action<string> write1 = delegate(string s) { Console.WriteLine(s); };

            void write2(string str)
            {
                Console.WriteLine(str);
            }

            double Tg(double x)
            {
                return Math.Sin(x) / Math.Cos(x);
            }
            
            Console.WriteLine(Tg(60));

            write("Слово");
            write1("Слово");
            write2("Слово");
        }

        // 1 - value = 5
        // 2 - value = 4
        // 3 - value = 3
        static int FactorialRecursive(int factorial)
        {
            if (factorial == 1) return factorial;
            Console.WriteLine($"{nameof(factorial)} -> {factorial}");
            return factorial * FactorialRecursive(factorial - 1);
            // value * value - 1 * value - 2 * value - 3
            // 5 * 4 * 3 * 2 * 1
        }
        
        static int Factorial(int value)
        {
            int result = 1;
            for (int i = value; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        static void Concat(string str1)
        {
            Console.WriteLine($"{str1}");
        }
 
        static void Concat(string str1, string str2)
        {
            Console.WriteLine($"{str1} {str2}");
        }

        static void Concat(string str1, string str2, string str3)
        {
            Console.WriteLine($"{str1} {str2} {str3}");
        }

        static void Concat(params string[] strings)
        {
            Console.WriteLine(strings.Length);
        }

        static bool TryDivide(int a, int b, out int result)
        {
            result = a / b;
            return a % b == 0;
        }

        static void Increment(ref int i)
        {
            i++;
        }

        static bool IsOdd(int x)
        {
            return x % 2 == 0;
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sum(int a, int b, bool r = true)
        {
            if (r)
            {
                return a + b;
            }
            else
            {
                return a - b;
            }
        }

        static int SumNumbers(int a, int b)
        {
            int sum = 0;
            for (int i = a; i <= b; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}