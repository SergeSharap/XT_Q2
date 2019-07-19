using System;

namespace _2._6
{
    public class Ring
    {
        private Round inner;
        private Round outer;
        public Point Center { get; set; }

        public Ring(double inRadius, double outRadius, double x, double y)
        {
            if (inRadius < outRadius)
            {
                inner = new Round(inRadius);
                outer = new Round(outRadius);
                Center = new Point(x, y);
            }
            else
                throw new ArgumentException("The inner round must be less than outer radius");
        }

        public Round Inner
        {
            get => inner;
            set
            {
                if (value.Radius < Outer.Radius)
                    inner = value;
                else
                    throw new ArgumentException("The inner round must be less than outer radius");
            }
        }
        public Round Outer
        {
            get => outer;
            set
            {
                if (value.Radius > Outer.Radius)
                    outer = value;
                else
                    throw new ArgumentException("The outer round must be more than inner radius");
            }
        }
        public double Area => outer.Area - inner.Area; 
        public double SumOfСircumferences => outer.Сircumference + inner.Сircumference; 

        public void SetCenter(double x, double y)
        {
            Center = new Point(x, y);
        }
    }
}
