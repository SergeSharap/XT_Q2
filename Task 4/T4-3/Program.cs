using System;


namespace T4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter.OnSorted += Message;
            string[] s = new string[]
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
            
            foreach (var w in s)
                Console.WriteLine(w);
            Console.WriteLine();

            string[] s1 = Sorter.SortInIndividualThread(s, CompareStrings);
            string[] s2 = Sorter.SortInIndividualThread(s, CompareStrings);

            foreach (var w in s1)
                Console.WriteLine(w);

            foreach (var w in s2)
                Console.WriteLine(w);
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
                else if (s1[i] < s2[i])
                    return -1;
            }

            return 0;
        }

        public static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
