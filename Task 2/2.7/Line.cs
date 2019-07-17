using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Line : Figure
    {
        private Point firstPoint;
        private Point secondPoint;

        public Line(double p1x, double p1y, double p2x, double p2y)
        {
            if (!IsPointsEqual(new Point(p1x, p1y), new Point(p2x, p2y)))
            {
                firstPoint = new Point(p1x, p1y);
                secondPoint = new Point(p2x, p2y);
            }
            else
                throw new ArgumentException("The points must not be equal");
        }

        public double Length { get => Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2)); }
        public Point FirstPoint
        {
            get => firstPoint;
            set
            {
                if (!IsPointsEqual(value, secondPoint))
                    firstPoint = value;
                else
                    throw new ArgumentException("The first point must be Point class and not equal to second point");
            }
        }
        public Point SecondtPoint
        {
            get => secondPoint;
            set
            {
                if (!IsPointsEqual(value, firstPoint))
                    secondPoint = value;
                else
                    throw new ArgumentException("The last point must be Point class and not equal to first point");
            }
        }

        private bool IsPointsEqual(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public override string ToString()
        {
            return "Line";
        }
        public override void Draw()
        {
            Console.WriteLine("Figure: " + this.ToString()
            + Environment.NewLine + "First point coordinate: (" + FirstPoint.X + ", " + FirstPoint.Y + ")"
            + Environment.NewLine + "Second point coordinate: (" + SecondtPoint.X + ", " + SecondtPoint.Y + ")"
            + Environment.NewLine + "Length: " + Length
            );
        }
        public void SetPoints(Point p1, Point p2)
        {
            if (IsPointsEqual(p1, p2))
                throw new ArgumentException("The points must not be equal");

            firstPoint = p1;
            secondPoint = p2;
        }
    }
}
