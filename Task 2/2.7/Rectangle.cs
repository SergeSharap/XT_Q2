using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Rectangle : Figure
    {
        private Point leftTop;
        private double width;
        private double height;

        public Rectangle(double x, double y, double w, double h)
        {
            leftTop = new Point(x, y);
            Width = w;
            Heigth = h;
        }

        public Point LeftTop
        {
            get => leftTop;
            set
            {
                if (value is Point)
                    leftTop = (Point)value;
                else
                    throw new ArgumentException("The point  must be Point class");
            }
        }
        public double Width
        {
            get => width;
            set
            {
                if (value > 0)
                    width = value;
                else
                    throw new ArgumentException("The width cannot be negative or zero");
            }
        }
        public double Heigth
        {
            get => height;
            set
            {
                if (value > 0)
                    height = value;
                else
                    throw new ArgumentException("The height cannot be negative or zero");
            }
        }
        public double Area { get => Width * Heigth; }

        public override string ToString()
        {
            return "Rectangle";
        }
        public override void Draw()
        {
            Console.WriteLine("Figure: " + this.ToString()
            + Environment.NewLine + "First point coordinate: (" + LeftTop.X + ", " + LeftTop.Y + ")"
            + Environment.NewLine + "Width: " + Width
            + Environment.NewLine + "Height: " + Heigth
            + Environment.NewLine + "Area: " + Area);
        }
    }
}
