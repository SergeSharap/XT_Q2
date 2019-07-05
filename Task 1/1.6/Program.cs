using System;

namespace CSharp
{
    class Program
    {
        [Flags]
        public enum Style
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }
        static void Main(string[] args)
        {
            FontAdjustment();
        }
        private static void FontAdjustment()
        {
            Style style = Style.None;
            bool quit = false;
            do
            {
                Console.WriteLine(Environment.NewLine + "Current text style is " + style);
                Console.WriteLine("Input:");
                for (int i = 1; i <= 3; i++)
                {
                    Style s = (Style)(int)Math.Pow(2, i - 1);
                    Console.WriteLine("\t{0}: {1}", i, s);
                }
                Console.WriteLine("\t4: Quit");

                int power = -1;
                int selectedItem;
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        power = 0;
                        break;
                    case 2:
                        power = 1;
                        break;
                    case 3:
                        power = 2;
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        break;
                }

                if (power != -1)
                {
                    int realStyle = (int)Math.Pow(2, power);
                    style ^= (Style)realStyle;
                }
            }while (!quit);
        }
    }
}
