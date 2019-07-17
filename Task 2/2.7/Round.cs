using System;


namespace Task2
{
    public class Round : Circle
    {
        public Round(double x, double y, double rad) : base (x, y, rad)
        {      }
        public Round(double rad) : base (rad)
        {
            Radius = rad;
            Center = new Point(0, 0);
        }

        public double Area { get => Math.PI * Math.Pow(Radius, 2); }

        public override string ToString()
        {
            return "Round";
        }
        public override void Draw()
        {
            Console.WriteLine("Figure: " + this.ToString()
                + Environment.NewLine + "Coordinates of the center: (" + Center.X + ", " + Center.Y + ")"
                + Environment.NewLine + "Radius: " + Radius
                + Environment.NewLine + "Сircumference: " + Сircumference
                + Environment.NewLine + "Area: "+ Area);
        }
    }
}
