using System;

namespace Intro
{
    class General
    {
        public static string Sequence(int n)
        {
            string seq = "";

            for (int i = 1; i < n; i++)
            {
                seq = seq + i.ToString() + ", ";
            }
            return seq + n.ToString();
        }

        public static bool Simple(int n)
        {
            if (n == 1)
                return false;

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public static void Square(int n)
        {
            int mid = (n / 2) + 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == mid && j == mid)
                    {
                        Console.Write(" ");
                    }
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
