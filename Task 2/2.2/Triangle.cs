using System;

namespace _2._2
{
    public class Triangle
    {
        private const string ArgumentException = "Sides of the triangle must be positive and the sum of two side lengths of a triangle is always greater than the third side";
        private double a;
        private double b;
        private double c;
        
        public Triangle(double a, double b, double c)
        {
            if (DoesTriangleExist(a, b, c))
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
                throw new ArgumentException(ArgumentException);
        }

        public double A
        {
            get => a;
            set
            {
                if (value > 0 && DoesTriangleExist(value, B, C))
                    a = value;
                else
                    throw new ArgumentException(ArgumentException);
            }
        }
        public double B
        {
            get => b;
            set
            {
                if (value > 0 && DoesTriangleExist(A, value, C))
                    b = value;
                else
                    throw new ArgumentException(ArgumentException);
            }
        }
        public double C
        {
            get => c;
            set
            {
                if (value > 0 && DoesTriangleExist(A, B, value))
                    c = value;
                else
                    throw new ArgumentException(ArgumentException);
            }
        }

        public double Perimeter { get => A + B + C; }
        public double Area
        {
            get
            {
                double p = Perimeter / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        private bool DoesTriangleExist(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
        public void ChangeSides(double a, double b, double c)
        {
            if (DoesTriangleExist(a, b, c))
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
                throw new ArgumentException(ArgumentException);
        }
        public void ShowDetails()
        {
            Console.WriteLine("Side A = {0}.  Side B = {1}. Side C = {2}"
                + Environment.NewLine + "Perimeter: {3}"
                + Environment.NewLine + "Area: {4}", A, B, C, Perimeter, Area);
        }
    }
}
