using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BeginArrayProcessing();
            BeginNoPositive();
            BeginNonNegativeSum();
            BeginTwoDArray();
        }
        private static void BeginArrayProcessing()
        {
            Console.WriteLine(Environment.NewLine + "***Begin array processing***" + Environment.NewLine);
            int[] array = GetArray(10);
            ArrayProcessing(array);
        }

        private static void BeginNoPositive()
        {
            Console.WriteLine(Environment.NewLine + "***Begin no positive***" + Environment.NewLine);
            int[,,] array = GetArray(2, 2, 2);

            Console.Write("Original array: ");
            PrintArray(array);

            array = NoPositive(array);
            Console.Write("Array without positive numbers: ");
            PrintArray(array);

            Console.ReadKey();
        }

        private static void BeginNonNegativeSum()
        {
            Console.WriteLine(Environment.NewLine + "***Begin Non-negative sum***" + Environment.NewLine);
            int[] array = GetArray(10);

            Console.Write("Original array: ");
            PrintArray(array);
            Console.Write("Sum of non-negative array's elements: {0}", NonNegativeSum(array));

            Console.ReadKey();
        }
        private static void BeginTwoDArray()
        {
            Console.WriteLine(Environment.NewLine + "***Begin 2D array***" + Environment.NewLine);
            int[,] array = GetArray(4, 4);

            Console.WriteLine("Original array: ");
            PrintArray(array);
            Console.Write("Sum: {0}", TwoDArray(array));

            Console.ReadKey();
        }
        private static int Partition(int[] array, int start, int end)
        {
            int tmp;
            int mark = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] < array[end])
                {
                    tmp = array[mark];
                    array[mark] = array[i];
                    array[i] = tmp;
                    mark += 1;
                }
            }
            tmp = array[mark];
            array[mark] = array[end];
            array[end] = tmp;
            return mark;
        }
        private static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }
        public static void ArrayProcessing(int[] array)
        {
            int min = array[0];
            int max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
                else if (array[i] < min)
                    min = array[i];
            }
            Console.WriteLine($"Min: {min}, Max: {max}");

            QuickSort(array, 0, array.Length - 1);
            PrintArray(array);

            Console.ReadKey();
        }

        public static int[,,] NoPositive(int[,,] threeDArray)
        {
            for (int i = 0; i < threeDArray.GetLength(0); i++)
                for (int j = 0; j < threeDArray.GetLength(1); j++)
                    for (int z = 0; z < threeDArray.GetLength(2); z++)
                        if (threeDArray[i, j, z] > 0)
                            threeDArray[i, j, z] = 0;

            return threeDArray;
        }

        public static int NonNegativeSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                if (array[i] > 0)
                    sum += array[i];

            return sum;
        }

        public static int TwoDArray(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if ((i + j) % 2 == 0)
                        sum += array[i, j];

            return sum;
        }

        public static int[] GetArray(int numberOfElements)
        {
            int[] arr = new int[numberOfElements];
            Random rand = new Random();

            for (int i = 0; i < numberOfElements; i++)
                arr[i] = rand.Next(-100, 100);

            return arr;
        }
        public static int[,] GetArray(int x, int y)
        {
            int[,] arr = new int[x, y];
            Random rand = new Random();

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    arr[i, j] = rand.Next(-100, 100);

            return arr;
        }
        public static int[,,] GetArray(int x, int y, int z)
        {
            int[,,] arr = new int[x, y, z];
            Random rand = new Random();

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    for (int p = 0; p < z; p++)
                        arr[i, j, p] = rand.Next(-100, 100);

            return arr;
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");
            Console.WriteLine();
        }
        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j]} ");
                Console.WriteLine();
            }
        }
        public static void PrintArray(int[,,] array)
        {
            foreach (int i in array)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
}
