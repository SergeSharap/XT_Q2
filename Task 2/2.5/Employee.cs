using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Employee : User
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
            Console.WriteLine("First name: {0}."
                + Environment.NewLine + "Second name: {1}"
                + Environment.NewLine + "Patronymic: {2}"
                + Environment.NewLine + "The date of birth: {3}"
                + Environment.NewLine + "Age: {4}"
                + Environment.NewLine + "Position: {5}"
                + Environment.NewLine + "Work experience: {6}", FirstName, SecondName, Patronymic, DateBirthday, Age, Position, WorkExperience);
        }
    }
}
