using System;

namespace _2._8
{
    public struct Point
    {
        private int x;
        private int y;

        public int X
        {
            get => x;
            set
            {
                if (IsPointCorrect(value, y))
                    x = value;
                else
                    throw new  ArgumentException("Coordinate x cannot be negative");
            }
        }

        public int Y
        {
            get => y;
            set
            {
                if (IsPointCorrect(x, value))
                    y = value;
                else
                    throw new ArgumentException("Coordinate y cannot be negative");
            }
        }

        public Point(int x, int y)
        {
            if (IsPointCorrect(x, y))
            {
                this.x = x;
                this.y = y;
            }
            else
                throw new ArgumentException("Coordinates cannot be negative");
        }

        private static bool IsPointCorrect(int x, int y)
        {
            return x >= 0 && y >= 0;
        }
    }
}
