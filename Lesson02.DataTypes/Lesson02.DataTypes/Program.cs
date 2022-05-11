using System;

namespace Lesson02.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int b = 3;

            short s;
            s = 300;

            uint ui = 23232;
            int si = -3000;

            int i = 5;
            int result = ++i + i++;

            Console.WriteLine(result);
            Console.WriteLine(i);

            Console.WriteLine(a * 3);           // 6
            Console.WriteLine(18 / b);          // 6
            Console.WriteLine(10 % 3);          // 1
            Console.WriteLine(10 / 3);          // 3

            short biiiigInt = 32000;
            short biiiigInt1 = 3200;

            unchecked
            {
                short result1 = (short)(biiiigInt + short.Parse("32000"));
                //Convert.ToByte("120000");
            }

            int resultInt = biiiigInt;

            //2 - 00000010 => 00010000
            //2 - 00000010 => 00010000
            Console.WriteLine(a << b);
            Console.WriteLine(16 >> 100);

            int aA = 4;
            int bB = 10;

            Console.WriteLine(aA < bB);     // true
            Console.WriteLine(aA > bB);     // false
            Console.WriteLine(!(aA > bB));     // true
            Console.WriteLine(!(aA == bB));    // true
            Console.WriteLine(aA != bB);    // true

            bool aBool = true;
            bool bBool = false;
            Console.WriteLine(aBool | bBool);           // true
            Console.WriteLine(aBool || bBool);          // true
            Console.WriteLine(true || false && false);  // true
            Console.WriteLine(false && true && false);  // false
            Console.WriteLine(false & true & false);    // false

            // 4 -  00000100
            // 10 - 00001010
            // r -  00001110
            Console.WriteLine(aA | bB);     // 14

            // 4 -  00000100
            // 10 - 00001010
            // r -  00000000
            Console.WriteLine(aA & bB);    // 0


            // 6 -  00000110
            // 10 - 00001010
            // r -  00001100
            Console.WriteLine(6 ^ 10);    // 12

            // true -  0001
            // false - 0000
            // r -     0001
            Console.WriteLine(true | false);
            
            // aA - 4
            // bB - 10
            aA = aA + 10;
            aA += 10;
            aA *= 10;
            aA = aA * 10;
            Console.WriteLine(aA);      // 2400

            Console.WriteLine(bB + bB++);          // 20
            Console.WriteLine(bB);                 // 11

            bB = 10;

            Console.WriteLine(bB++ + bB);          // 21
            Console.WriteLine(bB);                 // 11

            double d = 3.223423423;
            Console.WriteLine(Math.Pow(d, 2));      // > 9
            Console.WriteLine(Math.Ceiling(d));     // 4
            Console.WriteLine(Math.Round(d));       // 3
            Console.WriteLine(Math.Floor(d));       // 3
            Console.WriteLine(Math.Max(5,2));       // 5
            Console.WriteLine(Math.Min(5,2));       // 2
            Console.WriteLine(Math.Min(5,2));       // 2
            Console.WriteLine(Math.Round(3.5, MidpointRounding.ToZero));       // 2

            //changes
            
            Console.ReadKey();
        }
    }
}
