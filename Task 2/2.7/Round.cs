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

        public double Area => Math.PI * Math.Pow(Radius, 2); 

        public override string ToString()
        {
            return "Round";
        }
        public override void Draw()
        {
            base.Draw();
            Console.WriteLine("Area: "+ Area);
        }
    }
}
