using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Menu
    {
        public void Choice()
        {
            Round round = null;
            bool quit = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" + Environment.NewLine);
                Console.WriteLine("1. Create round"
                    + Environment.NewLine + "2. Change coordinates of the center"
                    + Environment.NewLine + "3. Change radius"
                    + Environment.NewLine + "4. Show details"
                    + Environment.NewLine + "5. Quit"
                    );

                int selectedItem;
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        round = RoundCreater();
                        break;
                    case 2:
                        if (round != null)
                            ChangeCoordinates(ref round);
                        else
                        {
                            Console.WriteLine("You have not created round yet");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (round != null)
                            ChangeRadius(ref round);
                        else
                        {
                            Console.WriteLine("You have not created round yet");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        if (round != null)
                        {
                            round.Draw();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You have not created round yet");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }
        private Round RoundCreater()
        {
            double x, y, r;
            x = Input("Please enter x coordinate of the circle's center");
            y = Input("Please enter y coordinate of the circle's center");
            r = Input("Please enter the radius");

            try
            {
                Round round = new Round(x, y, r);
                return round;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return null;
            }
        }
        private void ChangeCoordinates(ref Round round)
        {
            double x, y;
            x = Input("Please enter x coordinate of the circle's center");
            y = Input("Please enter y coordinate of the circle's center");
            round.Center = new Point(x, y);
        }
        private void ChangeRadius(ref Round round)
        {
            double r;
            r = Input("Please enter the radius");
            try
            {
                round.Radius = r;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private double Input(string message)
        {
            double n;
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = Double.TryParse(Console.ReadLine(), out n);

                if (isCorrectParse)
                    return n;
                else if (!isCorrectParse)
                    Console.WriteLine("You entered not a number");
            }
        }
    }
}
