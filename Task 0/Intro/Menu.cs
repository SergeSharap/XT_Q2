using System;
using System.Collections.Generic;

namespace Intro
{
    class Menu
    {
        List<string> listOfTasks = new List<string>() { "Sequence", "Simple", "Square" };
        public void Choice()
        {
            bool quit = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Select task:\n");
                PrintTasks(listOfTasks);

                int selectedItem;
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        BeginSequence();
                        break;
                    case 2:
                        BeginSimple();
                        break;
                    case 3:
                        BeginSquare();
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }

        private void BeginSequence()
        {
            int n = Input(false, "Please enter positive integer.");

            Console.WriteLine("Your sequence of numbers: " + General.Sequence(n));
            Console.ReadKey();
        }

        private void BeginSimple()
        {
            int n = Input(false, "Please enter positive integer.");

            if (General.Simple(n))
                Console.WriteLine("Your number is simple.");
            else
                Console.WriteLine("Your number is not simple.");
            Console.ReadKey();
        }

        private void BeginSquare()
        {
            int n = Input(true, "Please enter odd positive integer.");

            Console.WriteLine("Your square:");
            General.Square(n);
            Console.ReadKey();
        }

        private void PrintTasks(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, list[i]);
            }
            Console.WriteLine("{0}.Quit", list.Count + 1);
        }

        //Если в данный метод в параметр odd передать значение true,
        //то будет осуществлена дополнительная проверка на нечётность числа
        private int Input(bool odd, string message)
        {
            int n;
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = Int32.TryParse(Console.ReadLine(), out n);

                if (isCorrectParse && n > 0)
                {
                    if (!odd)
                        return n;
                    else if (n % 2 == 1)
                        return n;
                    else
                        Console.WriteLine("You entered incorrect number.");
                }
                else
                    Console.WriteLine("You entered incorrect number.");
            }
        }
    }
}
