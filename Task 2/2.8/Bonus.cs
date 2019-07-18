namespace _2._8
{ 
    public class Bonus
    {
        private readonly KindsOfBonus bonus;

        public Bonus(KindsOfBonus kind)
        {
            bonus = kind;
        }
        public enum KindsOfBonus
        {
            Apple = 0,
            Banana = 1,
            Orange = 2
        }

        public void Eaten(KindsOfBonus kind)
        {
            switch ((int)kind)
            {
                case 0:
                    player.curSpeed += 1;
                    break;
                case 1:
                    player.Lives += 1;
                    break;
                case 2:
                    player.curSpeed += 2;
                    break;
            }
        }

    }
}
