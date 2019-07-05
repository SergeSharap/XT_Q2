using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BeginRectangle();
            BeginTriangle();
            BeginAnotherTriangle();
            BeginXMasTree();
        }

        private static void BeginRectangle()
        {
            Console.WriteLine(Environment.NewLine + "***Begin rectangle***" + Environment.NewLine);
            int a = Input("Please enter positive integer");
            int b = Input("Please enter positive integer");
            Console.WriteLine("Area of the rectangle: {0}", Rectangle(a, b));

            Console.ReadKey();
        }
        private static void BeginTriangle()
        {
            Console.WriteLine(Environment.NewLine + "***Begin triangle***" + Environment.NewLine);
            int n = Input("Please enter positive integer");

            Console.WriteLine("Your triangle: ");
            Triangle(n);

            Console.ReadKey();
        }

        private static void BeginAnotherTriangle()
        {
            Console.WriteLine(Environment.NewLine + "***Begin another triangle***" + Environment.NewLine);
            int n = Input("Please enter positive integer");

            Console.WriteLine("Your another triangle: ");
            AnotherTriangle(n);

            Console.ReadKey();
        }

        private static void BeginXMasTree()
        {
            Console.WriteLine(Environment.NewLine + "***Begin X-mas tree***" + Environment.NewLine);
            int n = Input("Please enter positive integer");

            Console.WriteLine("Your X-Mas tree: ");
            XMasTree(n);

            Console.ReadKey();
        }

        private static int Rectangle(int a, int b) => a * b;

        private static void Triangle(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(new String('*', i));
            }
        }

        private static void AnotherTriangle(int n)
        {
            int x = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                Console.WriteLine(new String(' ', i) + new String('*', x));
                x += 2;
            }
        }

        private static void XMasTree(int n)
        {
            for (int j = 1; j <= n; j++)
            {
                int x = 1;
                for (int i = j - 1; i >= 0; i--)
                {
                    Console.WriteLine(new String(' ', i + n - j) + new String('*', x));
                    x += 2;
                }
            }
        }
        private static int Input(string message)
        {
            int n;
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = Int32.TryParse(Console.ReadLine(), out n);

                if (isCorrectParse && n > 0)
                    return n;
                else if (!isCorrectParse)
                    continue;
                else
                    Console.WriteLine("You entered incorrect number.");
            }
        }
    }
}
