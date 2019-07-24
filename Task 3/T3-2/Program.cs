using System;
using System.Collections.Generic;

namespace T3_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string str = "Word. Word new NEW New.Word word Love";
            Dictionary<string, int> frequency =  WordsFrequency(str);

            foreach (KeyValuePair<string, int> word in frequency)
            {
                Console.WriteLine("Word: {0} | Frequency: {1}", word.Key, word.Value);
            }

            Console.ReadKey();
        }
        public static Dictionary<string, int> WordsFrequency(string text)
        {
            text = text.ToLower();
            string[] words = text.Split(new[] { ' ', '.' }, System.StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> frequencyOfWords = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (frequencyOfWords.ContainsKey(word))
                    frequencyOfWords[word] += 1;
                else
                    frequencyOfWords.Add(word, 1);
            }

            return frequencyOfWords;
        }
    }
}
