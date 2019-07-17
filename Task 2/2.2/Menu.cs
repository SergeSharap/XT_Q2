using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Menu
    {
        public void Choice()
        {
            Triangle triangle = null;
            bool quit = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" + Environment.NewLine);
                Console.WriteLine("1. Create triangle"
                    + Environment.NewLine + "2. Change triangle"
                    + Environment.NewLine + "3. Show details"
                    + Environment.NewLine + "4. Quit"
                    );

                int selectedItem;
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        triangle = TriangleCreater();
                        break;
                    case 2:
                        if (triangle != null)
                            ChangeTriangle(ref triangle);
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
        private Triangle TriangleCreater()
        {
            double a, b, c;
            a = Input("Please enter a side of the triangle");
            b = Input("Please enter b side of the triangle");
            c = Input("Please enter c side of the triangle");

            try
            {
                Triangle triangle = new Triangle(a, b, c);
                return triangle;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return null;
            }
        }
        private void ChangeTriangle(ref Triangle triangle)
        {
            double a, b, c;
            a = Input("Please enter a side of the triangle");
            b = Input("Please enter b side of the triangle");
            c = Input("Please enter c side of the triangle");

            try
            {
                triangle.ChangeSides(a, b, c);
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
