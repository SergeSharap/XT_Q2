using System;
using System.Collections.Generic;

namespace T3_1
{
    class Program
    {
        static void Main()
        {
            List<string> people = new List<string>()
            {
                "Sergei",
                "Anton",
                "Lena",
                "John",
                "Michael",
                "Roman",
                "Max"
            };

            foreach (var t in people)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine();
            int index = 0;
            for (int i = 0; i <= people.Count; i++, index++)
            {
                if (people.Count == 1)
                    break;

                if (people.Count == i)
                    i = 0;

                if (index % 2 != 1) continue;

                Console.WriteLine("Leaving: {0}", people[i]);
                people.RemoveAt(i);
                i--;
            }

            Console.WriteLine(people[0]);
        }
    }
}
