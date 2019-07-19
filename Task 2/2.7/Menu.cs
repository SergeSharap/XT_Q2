using System;
using System.Collections.Generic;

namespace _2._7
{
    public class Menu
    {
        private int selectedItem;
        private List<Figure> figures = new List<Figure>();
        private bool quit = false;

        public void Choice()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" + Environment.NewLine);
                Console.WriteLine("1. Create circle"
                    + Environment.NewLine + "2. Create round"
                    + Environment.NewLine + "3. Create ring"
                    + Environment.NewLine + "4. Create line"
                    + Environment.NewLine + "5. Create rectangle"
                    + Environment.NewLine + "6. Draw all figures"
                    + Environment.NewLine + "7. Quit"
                    );

                
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        CircleCreater();
                        break;
                    case 2:
                        RoundCreater();
                        break;
                    case 3:
                        RingCreater();
                        break;
                    case 4:
                        LineCreater();
                        break;
                    case 5:
                        RectangleCreater();
                        break;
                    case 6:
                        DrawAllFigures();
                        break;
                    case 7:
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }
        private void CircleCreater()
        {
            double x = Input("Please enter x coordinate of the circle's center");
            double y = Input("Please enter y coordinate of the circle's center");
            double r = Input("Please enter the radius");

            try
            {
                Circle circle = new Circle(x, y, r);
                figures.Add(circle);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void RoundCreater()
        {
            double x = Input("Please enter x coordinate of the round's center");
            double y = Input("Please enter y coordinate of the round's center");
            double r = Input("Please enter the radius");

            try
            {
                Round round = new Round(x, y, r);
                figures.Add(round);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void RingCreater()
        {
            double x = Input("Please enter x coordinate of the ring's center");
            double y = Input("Please enter y coordinate of the ring's center");
            double rIn = Input("Please enter the inner radius");
            double rOut = Input("Please enter the outer radius");

            try
            {
                Ring ring = new Ring(rIn, rOut, x, y );
                figures.Add(ring);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void LineCreater()
        {
            double x1 = Input("Please enter x coordinate of first point");
            double y1 = Input("Please enter y coordinate of first point");
            double x2 = Input("Please enter y coordinate of second point");
            double y2 = Input("Please enter y coordinate of second point");

            try
            {
                Line line = new Line(x1, y1, x2, y2);
                figures.Add(line);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void RectangleCreater()
        {
            double x = Input("Please enter x coordinate of left top point");
            double y = Input("Please enter y coordinate of left top point");
            double w = Input("Please enter width of the rectangle");
            double h = Input("Please enter height of the rectangle");

            try
            {
                Rectangle rectangle = new Rectangle(x, y, w, h);
                figures.Add(rectangle);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void DrawAllFigures()
        {
            foreach (Figure figure in figures)
            {
                figure.Draw();
                Console.WriteLine();
            }
            Console.ReadKey();
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
