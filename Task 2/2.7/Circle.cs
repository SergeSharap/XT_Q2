using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Circle : Figure
    {
        private double radius;
        public Point Center { get; set; }

        public Circle(double x, double y, double rad)
        {
            Center = new Point(x, y);
            Radius = rad;
        }
        public Circle(double rad)
        {
            Radius = rad;
            Center = new Point(0, 0);
        }

        public double Radius
        {
            get => radius;
            set
            {
                if (value > 0)
                    radius = value;
                else
                    throw new ArgumentException("The radius cannot be negative or zero");
            }
        }

        public double Сircumference => 2 * Math.PI * Radius; 

        public override string ToString()
        {
            return "Circle";
        }
        public override void Draw()
        {
            Console.WriteLine("Figure: " + this.ToString()
                + Environment.NewLine + "Coordinates of the center: (" + Center.X + ", " + Center.Y + ")"
                + Environment.NewLine + "Radius: " + Radius
                + Environment.NewLine + "Сircumference: " + Сircumference);
        }
        public void SetCenter(double x, double y)
        {
            Center = new Point(x, y);
        }
    }
}
