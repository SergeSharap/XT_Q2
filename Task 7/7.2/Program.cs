using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7._2
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a text: ");
            string str = Console.ReadLine();
            Console.WriteLine("Result: " + ReplaceHtmlTags(str));
            Console.ReadKey();
        }

        private static string ReplaceHtmlTags(string str)
        {
            string pattern = "<.*?>";
            Regex regex = new Regex(pattern);
            return regex.Replace(str, "_");
        }
    }
}
