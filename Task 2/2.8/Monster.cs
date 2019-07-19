using System;

namespace _2._8
{

    public class Monster : LivingThing
    {
        public KindsOfMonster MonsterKind { get; }

        public Monster(Point p, int max, int cur, KindsOfMonster kind) : base (p, max, cur)
        {
            MonsterKind = kind;
        }

        public enum KindsOfMonster
        {
            Wolf = 0,
            Bear = 1,
            Snake = 2
        }


        public void Eat(KindsOfMonster kind, Player player)
        {
            switch ((int)kind)
            {
                case 0:
                    player.Lives -= 1;
                    break;
                case 1:
                    player.Lives -= 1;
                    break;
                case 2:
                    player.CurrentSpeed -= 2;
                    break;
            }
        }
    }
}
