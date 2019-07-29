using System;
using System.Collections.Generic;
using System.Linq;

namespace T4_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = GetArray(10);

            Console.Write("Original array: ");
            PrintArray(array);

            Console.WriteLine(Environment.NewLine + "Arrays with only positive numbers:" + Environment.NewLine);

            Console.Write("Using search method: ");
            int[] arrayOfPositiveNumbers = GetArrayOfPositiveNumbers(array);
            PrintArray(arrayOfPositiveNumbers);
            Console.WriteLine();

            Console.Write("Using delegate instance: ");
            Predicate<int> condition = Selection;
            arrayOfPositiveNumbers = GetArrayOfPositiveNumbers(array, condition);
            PrintArray(arrayOfPositiveNumbers);
            Console.WriteLine();
            
            Console.Write("Using anonymous method: ");
            arrayOfPositiveNumbers = GetArrayOfPositiveNumbers(array, delegate(int value) {return value > 0;});
            PrintArray(arrayOfPositiveNumbers);
            Console.WriteLine();

            Console.Write("Using lambda expression: ");
            arrayOfPositiveNumbers = GetArrayOfPositiveNumbers(array, value => value > 0);
            PrintArray(arrayOfPositiveNumbers);
            Console.WriteLine();

            Console.Write("Using LINQ expression: ");
            arrayOfPositiveNumbers = GetArrayOfPositiveNumbersLinq(array);
            PrintArray(arrayOfPositiveNumbers);

            Console.ReadKey();
        }

        public static bool Selection(int value)
        {
            return value > 0;
        }

        public static int[] GetArrayOfPositiveNumbers(IEnumerable<int> array)
        {
            List<int> arrayOfPositiveNumbers = new List<int>();

            foreach (int element in array)
            {
                if (element > 0)
                    arrayOfPositiveNumbers.Add(element);
            }

            return arrayOfPositiveNumbers.ToArray();
        }

        public static int[] GetArrayOfPositiveNumbers(IEnumerable<int> array, Predicate<int> condition)
        {
            List<int> arrayOfPositiveNumbers = new List<int>();

            foreach (int element in array)
            {
                if (condition(element))
                    arrayOfPositiveNumbers.Add(element);
            }

            return arrayOfPositiveNumbers.ToArray();
        }

        public static int[] GetArrayOfPositiveNumbersLinq(IEnumerable<int> array)
        {
            IEnumerable<int> arrayOfPositiveNumbers = from i in array
                                                        where i > 0
                                                        select i;
            return arrayOfPositiveNumbers.ToArray();
        }

        public static int[] GetArray(int length)
        {
            Random rand = new Random();
            int[] array = new int[length];

            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(-100, 100);

            return array;
        }

        public static void PrintArray(int[] array)
        {
            foreach (int element in array)
                Console.Write(element + " ");

            Console.WriteLine();
        }
    }
}
