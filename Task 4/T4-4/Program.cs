using System;

namespace T4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {3, 5, 7, -7, 2};
            Console.WriteLine(numbers.GetSum());
            double[] numbers2 = {2.5, 4.6, -2.5, 5.4};
            Console.WriteLine(numbers2.GetSum());

            Console.ReadKey();
        }
    }
}
