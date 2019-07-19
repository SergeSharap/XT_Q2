using System;

namespace _2._1
{
    public class Menu
    {
        private int selectedItem;
        private bool quit = false;
        private Round round = null;
        public void Choice()
        {
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

                
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        RoundCreater();
                        break;
                    case 2:
                        if (round != null)
                            ChangeCoordinates();
                        else
                        {
                            Console.WriteLine("You have not created round yet");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (round != null)
                            ChangeRadius();
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
        private void RoundCreater()
        {
            double x = Input("Please enter x coordinate of the circle's center");
            double y = Input("Please enter y coordinate of the circle's center");
            double r = Input("Please enter the radius");

            try
            {
                round = new Round(x, y, r);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void ChangeCoordinates()
        {
            double x = Input("Please enter x coordinate of the circle's center");
            double y = Input("Please enter y coordinate of the circle's center");
            round.Center = new Point(x, y);
        }
        private void ChangeRadius()
        {
            double r = Input("Please enter the radius");
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
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = Double.TryParse(Console.ReadLine(), out double n);

                if (isCorrectParse)
                    return n;
                else
                    Console.WriteLine("You entered not a number");
            }
        }
    }
}
