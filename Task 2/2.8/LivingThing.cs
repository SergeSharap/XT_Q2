using System;

namespace _2._8
{
    public abstract class LivingThing : IMovable
    {
        private Point currentPosition;
        private int currentSpeed;
        private readonly int maxSpeed;

        protected LivingThing(Point p, int max, int cur)
        {
            currentPosition = p;
            currentSpeed = cur;
            maxSpeed = max;
        }

        public Point CurrentPosition => currentPosition;

        public int CurrentSpeed
        {
            get => currentSpeed;
            set => currentSpeed = value >= maxSpeed ? maxSpeed : value; 
        }

        public void Move(Direction direction)
        {
            switch ((int)direction)
            {
                case 0:
                    currentPosition.X -= currentSpeed;
                    break;
                case 1:
                    currentPosition.X += currentSpeed;
                    break;
                case 2:
                    currentPosition.Y += currentSpeed;
                    break;
                case 3:
                    currentPosition.Y -= currentSpeed;
                    break;
            }
        }
    }
}
