namespace Lesson16.Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var array = Enumerable.Range(0, 10).Select(_ => random.Next(100)).ToArray();
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Sort(array);
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            array = Enumerable.Range(0, 10).Select(_ => random.Next(100)).ToArray();
            Sort<int>(array);

            string[] stringArray = Enumerable.Range(0, 10).Select(_ => $"{random.Next(100)}").ToArray();
            Sort<string>(stringArray);

            var instance = new MyClass();
            var arrayOfMyClass = new MyClass[10];

            int a = 2;
            a.CompareTo(4);

            CreateInstance<MyClass>();

            // q.Compare(1, 3);
            // IComparable comparable = instance;
            // MyClassBase @base = instance;
        }

        class MyClassBase<T>
        {

        }
        class MyClass :  MyClassBase<int>
        {

        }
        //
        // private static void Sort(int[] array)
        // {
        //     for (int i = 0; i < array.Length; i++)
        //     {
        //         for (int j = 0; j < array.Length - 1; j++)
        //         {
        //             IComparable<int> item1 = array[j];
        //
        //             if (item1.CompareTo(array[j + 1]) == -1)
        //             {
        //                 object o1 = array[j];
        //                 object o2 = array[j + 1];
        //
        //                 Swap(ref o1, ref o2);
        //
        //                 array[j] = (int)o1;
        //                 array[j + 1] = (int)o2;
        //
        //                 Swap<int>(ref array[j], ref array[j + 1]);
        //             }
        //         }
        //     }
        // }

        private static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        private static void Sort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    IComparable<T> item1 = array[j];

                    if (item1.CompareTo(array[j + 1]) == -1)
                    {
                        Swap<T>(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        // private static void Swap(ref object a, ref object b)
        // {
        //     // ReSharper disable once SwapViaDeconstruction
        //     var temp = a;
        //     a = b;
        //     b = temp;
        // }

        private static void Swap<T>(ref T a, ref T b)
        {
            // ReSharper disable once SwapViaDeconstruction
            T temp = a;
            a = b;
            b = temp;
        }
        //
        // private static void Sort(string[] array)
        // {
        //     for (int i = 0; i < array.Length; i++)
        //     {
        //         for (int j = 0; j < array.Length - 1; j++)
        //         {
        //             IComparable<string> item1 = array[j];
        //
        //             if (item1.CompareTo(array[j + 1]) == -1)
        //             {
        //                 Swap<string>(ref array[j], ref array[j + 1]);
        //             }
        //         }
        //     }
        // }
    }
}