using System;

namespace T4_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[]
            {
                "aa",
                "a",
                "ab",
                "aaa",
                "ZZ",
                "aaaaaa",
                "aaaa",
                "aaaaaaaaaa",
            };
            Console.WriteLine("Original array:");
            foreach (var w in array)
                Console.WriteLine(w);

            Console.WriteLine(Environment.NewLine + "Sorted array:");
            string[] sortedArray = Sort(array, CompareStrings);
            foreach (var w in sortedArray)
                Console.WriteLine(w);
        }

        public static T[] Sort<T> (T[] array, Func<T, T, int> comparer)
        {
            for (int i = 1; i < array.Length; i++)
            {
                T cur = array[i];
                int j = i;
                while (j > 0 && comparer?.Invoke(cur, array[j - 1]) == -1)//while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = cur;
            }

            return array;
        }

        public static int CompareStrings(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return 1;
            else if (s1.Length < s2.Length)
                return -1;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] > s2[i])
                    return 1;
                else if(s1[i] < s2[i])
                    return -1;
            }

            return 0;
        }
    }
}
