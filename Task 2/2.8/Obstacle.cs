using System;

namespace _2._8
{
    public class Obstacle
    {
        public Point Position { get; }
        public KindsOfObstacle ObstacleKind { get; }

        public Obstacle(Point p, KindsOfObstacle obstacle)
        {
            ObstacleKind = obstacle;
            Position = p;
        }

        public enum KindsOfObstacle
        {
            Tree = 0,
            Water = 1,
            Stone = 2,
        }
    }
}
