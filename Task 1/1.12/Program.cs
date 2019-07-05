using System;
using System.Text;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string str = Console.ReadLine();

            Console.WriteLine("Enter string for doubler:");
            string doubler = Console.ReadLine();

            string strWithDouble = CharDoubler(str, doubler);
            Console.WriteLine(strWithDouble);
            Console.ReadKey();
        }

        private static string CharDoubler(string message, string doubler)
        {
            StringBuilder str = new StringBuilder(message);
            char symb = ' ';

            for (int i = 0; i < doubler.Length; i++)
            {
                symb = doubler[i];
                str.Replace($"{doubler[i]}", new string(symb, 2));
            }

            string res = str.ToString();
            return res;
        }

    }
}
