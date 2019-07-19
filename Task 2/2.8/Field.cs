using System;

namespace _2._8
{
    public class Field
    {
        public int Width { get; }
        public int Height { get; }

        public Field(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                Width = width;
                Height = height;
            }
            else
                throw new ArgumentException("Width and height must be more than zero");
        }
    }


}
