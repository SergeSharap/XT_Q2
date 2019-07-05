using System;
using System.Collections.Generic;
using System.Text;
namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int avg = AVGStringLength("343Привет, Папа!     Как дела?");
            Console.WriteLine($"{avg}");
            Console.ReadKey();
        }

        public static int AVGStringLength(string text)
        {
            List<string> words = new List<string>();
            StringBuilder currentWord = new StringBuilder("");
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                    currentWord.Append(text[i]);
                else if ((Char.IsPunctuation(text[i]) || Char.IsSeparator(text[i]) ||
                    Char.IsDigit(text[i]) || i + 1 == text.Length) &&
                    currentWord.ToString() != "")
                {
                    words.Add(currentWord.ToString());
                    currentWord = new StringBuilder("");
                }

                if (Char.IsLetter(text[i]) && i + 1 == text.Length)
                {
                    words.Add(currentWord.ToString());
                }
            }
            for (int i = 0; i < words.Count; i++)
            {
                sum += words[i].Length;
            }
            double avg = (double)sum / (double)words.Count;
            return (int)Math.Round(avg);
        }
    }
}
