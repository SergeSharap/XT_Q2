using System;

namespace _2._8
{
    public class Player : LivingThing
    {
        private int lives;

        public Player(Point p, int max, int cur, int lives) : base(p, max, cur)
        {
            this.lives = lives;
        }

        public int Lives
        {
            get => lives;
            set
            {
                if (value == 0)
                    Death();
                else
                    lives = value;
            }
        }

        private void Death()
        {

        }
    }
}
