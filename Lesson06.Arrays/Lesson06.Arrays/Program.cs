namespace Lesson06.Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10]; // 10 items
            int[] array1 = new[] { 1, 2, 3, 4, 5 }; // 5 items
            int[] array2 = { 1, 2, 3, 4, 5 }; // 5 items


            int[] newArray = { 1, 2, 3 };

            array1[0] = 1;
            var index = new Index(0);
            array1[index] = 1;

            int[] range = array[2..4];

            array1[1] = 2;
            array1[2] = 3;

            Print(array);

            int i = 0;
            for (i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            Print(array);

            for (i = 0; i < array.Length; i++)
            {
                array[i] = i * 2;
            }

            Print(array);

            var randomArray = GetArray(10);
            Print(randomArray);
            MultipleBy(randomArray, 2);
            Print(randomArray);

            var copiedArray = Copy(randomArray);
            MultipleBy(copiedArray, 10);
            Print(randomArray);
            Print(copiedArray);

            Sort(randomArray);
            Print(randomArray);
        }

        // 4, 2, 8, 3, 7, 1
        // 1, 2, 8, 3, 7, 4
        // 1, 2, 3, 8, 7, 4
        // 1, 2, 3, 4, 8, 7
        // 1, 2, 3, 4, 7, 8
        private static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // ReSharper disable once SwapViaDeconstruction
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }

        // 4, 2, 8, 3, 7, 1
        // 4, 2, 8, 3, 7, 1
        // 2, 4, 8, 3, 7, 1
        // 2, 3, 4, 8, 7, 1
        // 2, 3, 4, 7, 8, 1
        // 1, 2, 3, 4, 7, 8
        private static void InsertionSort(int[] array)
        {
            
        }

        // 4, 2, 8, 3, 7, 1
        // 2, 4, 3, 7, 1, 8
        // 2, 3, 4, 1, 7, 8
        // 2, 3, 1, 4, 7, 8
        // 2, 1, 3, 4, 7, 8
        // 1, 2, 3, 4, 7, 8
        private static void BubbleSort(int[] array)
        {
            
        }

        private static int[] Copy(int[] array)
        {
            int[] copyArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                copyArray[i] = array[i];
            }

            return copyArray;
        }

        private static void MultipleBy(int[] array, int multiplier)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= multiplier;
            }
        }

        private static int[] GetArray(int length)
        {
            int maxValue = 100;
            Random random = new Random();
            var array = new int[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-maxValue, maxValue);
            }

            return array;
        }

        private static void Print(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            
            Console.Write(Environment.NewLine);
        }
    }
}