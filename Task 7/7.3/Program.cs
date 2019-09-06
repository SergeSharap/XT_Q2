using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a text: ");
            string text = Console.ReadLine();
            string[] emails = GetEmails(text);

            Console.WriteLine("Emails in your text:");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }

            Console.ReadKey();
        }

        private static string[] GetEmails(string input)
        {
            string pattern = @"\b[a-zA-Z\d][a-zA-Z\d\.\-_]*?[a-zA-Z\d]@([a-zA-Z\d][a-zA-Z\d\-]*?[a-zA-Z\d]\.)+[a-zA-Z]{2,6}\b";
            MatchCollection emailsMatch = Regex.Matches(input, pattern);
            string[] emails = new string[emailsMatch.Count];

            for (int i = 0; i < emailsMatch.Count; i++)
            {
                emails[i] = emailsMatch[i].Value;
            }

            return emails;
        }
    }
}
