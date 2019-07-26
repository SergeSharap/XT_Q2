using System;
using System.Collections.Generic;

namespace T3_1
{
    class Lost
    {
        private List<string> names = new List<string>()
        {
            "Sergei",
            "Anton",
            "Lena",
            "John",
            "Michael",
            "Roman",
            "Max",
            "Andrei",
            "Alexei",
            "Anna",
            "Daniel",
            "Sebastian"
        };

        public string GetLostMan()
        {
            int n = Input("Input number of people");
            List<string> people = GetPeople(n);

            foreach (string p in people)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            int index = 2;
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

            return people[0];
        }

        private List<string> GetPeople(int number)
        {
            string name;
            List<string> temp = new List<string>();
            Random r = new Random();

            for (int i = 0; i < number; i++)
            {
                name = names[r.Next(names.Count)];
                temp.Add(name);
            }
            return temp;
        }

        private int Input(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = int.TryParse(Console.ReadLine(), out int n);
                if (isCorrectParse && n > 0)
                    return n;
                else if (!isCorrectParse)
                    Console.WriteLine("You entered not a number");
                else
                    Console.WriteLine("You entered not positive number");
            }
        }
    }
}
