using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a text: ");
            string str = Console.ReadLine();
            Console.WriteLine(DoesStringContainDate(str)
            ? "This text contains date."
            : "This text doesn't contain date.");
            Console.ReadKey();
        }

        private static bool DoesStringContainDate(string str)
        {
            string pattern = @".*\d{2}-\d{2}-\d{4}.*";
            return Regex.IsMatch(str, pattern);
        }
    }
}
