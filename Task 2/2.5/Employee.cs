using System;

namespace _2._5
{
    public class Employee : User
    {
        private string position;
        private int workExperience;

        public Employee(string firstN, string secondN, string patr, DateTime dateBirth, string pos, int experience) : base(firstN, secondN, patr, dateBirth)
        {
            Position = pos;
            WorkExperience = experience;
        }

        public int WorkExperience
        {
            get => workExperience;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Work experience must be not negative and less than 101");
                else
                    workExperience = value;
            }
        }
        public string Position
        {
            get => position;
            set
            {
                if (value.Length > 50 || String.IsNullOrEmpty(value))
                    throw new ArgumentException("Position must be less than 51 characters and not empty");
                else
                    position = value;
            }
        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine("Position: {0}" + Environment.NewLine + "Work experience: {1}", Position, WorkExperience);
        }
    }
}
