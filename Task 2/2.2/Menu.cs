using System;

namespace _2._2
{
    public class Menu
    {
        private Triangle triangle = null;
        private bool quit = false;
        private int selectedItem;
        public void Choice()
        {

            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" + Environment.NewLine);
                Console.WriteLine("1. Create triangle"
                    + Environment.NewLine + "2. Change triangle"
                    + Environment.NewLine + "3. Show details"
                    + Environment.NewLine + "4. Quit"
                    );

                
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        TriangleCreater();
                        break;
                    case 2:
                        if (triangle != null)
                            ChangeTriangle();
                        else
                        {
                            Console.WriteLine("You have not created triangle yet");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (triangle != null)
                        {
                            triangle.ShowDetails();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You have not created triangle yet");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }
        private void TriangleCreater()
        {
            double a = Input("Please enter a side of the triangle");
            double b = Input("Please enter b side of the triangle");
            double c = Input("Please enter c side of the triangle");

            try
            {
                triangle = new Triangle(a, b, c);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private void ChangeTriangle()
        {
            double a = Input("Please enter a side of the triangle");
            double b = Input("Please enter b side of the triangle");
            double c = Input("Please enter c side of the triangle");

            try
            {
                triangle.ChangeSides(a, b, c);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
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
