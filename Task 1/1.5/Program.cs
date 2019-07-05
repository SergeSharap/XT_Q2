using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum of Numbers: {0}", SumOfNumbers());
            Console.ReadKey();
        }

        private static int SumOfNumbers()
        {
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            return sum;
        }
    }
}
