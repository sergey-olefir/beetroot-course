using System;
using System.Linq;

namespace Lesson15.Struct
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 100;
            object o = a;

            int b = (int)o;

            Console.WriteLine($"a value is {a.ToString()}");
            Console.WriteLine("a value is " + ((object)a).ToString());

            int[] array = Enumerable.Range(1, 3).ToArray();

            foreach (var i in array)
            {
                foreach (var j in array)
                {
                    Console.Write($"{(i * j).ToString()}     ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(o);
            Console.WriteLine(b);

            int x = 4;
            int y = 5;
            var vector1 = new Vector2D(x, y);
            var vector2 = new Vector2D(x, y);

            int z = x + y;
            var vector3 = Vector2D.Add(vector1, vector2);
            var vector4 = vector1 + vector2;

            Console.WriteLine($"vector {vector3}");
            Console.WriteLine($"vector ({vector4.X}, {vector4.Y})");
            Console.WriteLine(vector1 == vector2);
            Console.WriteLine(vector1 == vector3);
            Console.WriteLine(++vector1);

            int v = vector1;
            Console.WriteLine(v);

            int number = 10;
            Vector2D fromNumber = (Vector2D)number;
            Console.WriteLine($"{fromNumber}");
            Console.WriteLine(fromNumber);

            Console.WriteLine(fromNumber[0]);

            fromNumber[1] = 12;
            Console.WriteLine($"{fromNumber}");

            int sfsdf = fromNumber.ToInt();
            int fsdfsd = fromNumber;

            byte bt = 23;
            int wr = bt;

            byte sdf = (byte)wr;
        }

        public struct Vector2D
        {
            public int X { get; set; }

            public int Y { get; set; }

            public override string ToString() => $"({X}, {Y})";

            public Vector2D(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int this[int index]
            {
                get
                {
                    if (index < 0 || index > 1) throw new ArgumentException("");
                    return index == 0 ? this.X : this.Y;
                }
                set
                {
                    if (index < 0 || index > 1) throw new ArgumentException("");
                    if (index == 0)
                    {
                        X = value;
                    }

                    this.Y = value;
                }
            }

            public static implicit operator int(Vector2D vector2D)
            {
                return vector2D.X * vector2D.X + vector2D.Y * vector2D.Y;
            }

            public static implicit operator float(Vector2D vector2D)
            {
                return vector2D.X * vector2D.X + vector2D.Y * vector2D.Y;
            }

            public int ToInt()
            {
                return X * X + Y * Y;
            }

            public static explicit operator Vector2D(int vector2D)
            {
                return new Vector2D(vector2D, vector2D);
            }

            public Vector2D Add(Vector2D vector2D)
            {
                return new Vector2D(X + vector2D.X, Y + vector2D.Y);
            }

            public static Vector2D Add(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
            }

            public static Vector2D operator +(Vector2D v1, Vector2D v2)
            {
                return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
            }

            public static bool operator ==(Vector2D v1, Vector2D v2)
            {
                return v1.X == v2.X && v1.Y == v2.Y;
            }

            public static bool operator !=(Vector2D v1, Vector2D v2)
            {
                return v1.X != v2.X || v1.Y != v2.Y;
            }

            public static Vector2D operator ++(Vector2D vector2D)
            {
                return new Vector2D(vector2D.X + 1, vector2D.Y + 1);
            }
        }
    }
}