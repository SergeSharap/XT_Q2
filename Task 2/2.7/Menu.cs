using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Menu
    {
        private int selectedItem;
        private List<Figure> figures = new List<Figure>();
        private bool quit = false;
        private double n;
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
            double x, y, r;
            x = Input("Please enter x coordinate of the circle's center");
            y = Input("Please enter y coordinate of the circle's center");
            r = Input("Please enter the radius");

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
            double x, y, r;
            x = Input("Please enter x coordinate of the round's center");
            y = Input("Please enter y coordinate of the round's center");
            r = Input("Please enter the radius");

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
            double x, y, rIn, rOut;
            x = Input("Please enter x coordinate of the ring's center");
            y = Input("Please enter y coordinate of the ring's center");
            rIn = Input("Please enter the inner radius");
            rOut = Input("Please enter the outer radius");

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
            double x1, y1, x2, y2;
            x1 = Input("Please enter x coordinate of first point");
            y1 = Input("Please enter y coordinate of first point");
            x2 = Input("Please enter y coordinate of second point");
            y2 = Input("Please enter y coordinate of second point");

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
            double x, y, h, w;
            x = Input("Please enter x coordinate of left top point");
            y = Input("Please enter y coordinate of left top point");
            w = Input("Please enter width of the rectangle");
            h = Input("Please enter height of the rectangle");

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
                bool isCorrectParse = Double.TryParse(Console.ReadLine(), out n);

                if (isCorrectParse)
                    return n;
                else
                    Console.WriteLine("You entered not a number");
            }
        }
    }
}
