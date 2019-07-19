using System;

namespace _2._8
{ 
    public class Bonus
    {
        public Point Position { get; }
        public KindsOfBonus BonusKind { get; }

        public Bonus(KindsOfBonus kind, Point p)
        {
            BonusKind = kind;
            Position = p;
        }
        public enum KindsOfBonus
        {
            Apple = 0,
            Banana = 1,
            Orange = 2,
            PoisonMushroom = 3
        }

  

        public void Eaten(KindsOfBonus kind, Player player)
        {
            switch ((int)kind)
            {
                case 0:
                    player.CurrentSpeed += 1;
                    break;
                case 1:
                    player.Lives += 1;
                    break;
                case 2:
                    player.CurrentSpeed += 2;
                    break;
                case 3:
                    player.Lives -= 1;
                    break;
            }
        }

    }
}
