using System;

namespace Entities
{
    public class User
    {
        private string name;
        private DateTime dateOfBirth;

        public User(string name, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 40 || String.IsNullOrEmpty(value))
                    throw new ArgumentException("The name must be less than 41 characters and not empty");
                else
                    name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if (GetAge(value) < 0 || GetAge(value) > 140)
                    throw new ArgumentException("The age must be not negative and less than 141");
                else
                    dateOfBirth = value;
            }
        }

        public int Age => GetAge(dateOfBirth);

        public Guid Id { get; private set; }

        private int GetAge(DateTime dateBirth)
        {
            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - dateBirth.Year;

            if (dateNow.Month < dateBirth.Month || (dateNow.Month == dateBirth.Month && dateNow.Day < dateBirth.Day))
                year--;

            return year;
        }
    }
}