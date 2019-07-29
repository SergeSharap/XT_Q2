using System;

namespace T4_5
{
    class Program
    {
        static void Main()
        {
            string str = "+0088";
            
            Console.WriteLine(str.IsPositiveInteger());
        }
    }

    public static class StringExtension
    {
        public static bool IsPositiveInteger(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            if (str.StartsWith('-'))
                return false;

            int counterOfZero = 0;
            if (!(str.StartsWith('+') || char.IsDigit(str[0])))
                return false;
            else if (str[0] == '0' || str[0] == '+')
                counterOfZero++;

            
            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                    return false;

                if (str[i] == '0')
                    counterOfZero++;
            }

            if (counterOfZero == str.Length)
                return false;

            return true;
        }
    }
}
