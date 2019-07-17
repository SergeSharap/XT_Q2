using System;

namespace Task2
{
    public class Round
    {
        private double radius;
        public Point Center { get; set; }

        public Round(double x, double y, double rad)
        {
            Center = new Point(x, y);
            Radius = rad;
        }
        public Round(double rad)
        {
            Radius = rad;
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
        public double Сircumference { get => 2 * Math.PI * Radius; }
        public double Area { get => Math.PI * Math.Pow(Radius, 2); }

        public void Draw()
        {
            Console.WriteLine("Coordinates of the center: (" + Center.X + ", " + Center.Y + ")"
                + Environment.NewLine + "Radius: " + Radius
                + Environment.NewLine + "Сircumference: " + Сircumference
                + Environment.NewLine + "Area: " + Area);
        }
        public void SetCenter(double x, double y)
        {
            Center = new Point(x, y);
        }
    }
}
