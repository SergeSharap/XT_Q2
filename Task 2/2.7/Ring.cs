﻿using System;


namespace Task2
{
    public class Ring : Figure
    {
        private Round inner;
        private Round outer;
        private Point Center { get; set; }

        public Ring(double inRadius, double outRadius, double x, double y)
        {
            inner = new Round(inRadius);
            outer = new Round(outRadius);
            Center = new Point(x, y);
        }

        public Round Inner
        {
            get => inner;
            set
            {
                if (value is Round && value.Radius < Outer.Radius)
                    inner = (Round)value;
                else
                    throw new ArgumentException("The inner round must be Round class and less than outer radius");
            }
        }
        public Round Outer
        {
            get => outer;
            set
            {
                if (value is Round && value.Radius > Outer.Radius)
                    outer = (Round)value;
                else
                    throw new ArgumentException("The outer round must be Round class and more than inner radius");
            }
        }
        public double Area { get => outer.Area - inner.Area; }
        public double SumOfСircumferences { get => outer.Сircumference + inner.Сircumference; }

        public override string ToString()
        {
            return "Ring";
        }
        public override void Draw()
        {
            Console.WriteLine("Figure: " + this.ToString()
                + Environment.NewLine + "Coordinates of the centre: (" + Center.X + ", " + Center.Y + ")"
                + Environment.NewLine + "Inner radius: " + inner.Radius
                + Environment.NewLine + "Outer radius: " + outer.Radius
                + Environment.NewLine + "Sum of Сircumferences: " + SumOfСircumferences
                + Environment.NewLine + "Area: " + Area);
        }
        public void SetCenter(double x, double y)
        {
            Center = new Point(x, y);
        }
    }
}