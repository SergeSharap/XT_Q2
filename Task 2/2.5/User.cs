using System;

namespace _2._5
{
    public class User
    {
        private string firstName;
        private string secondName;
        private string patronymic;
        private DateTime dateBirthday;

        public User(string firstN, string secondN, string patr, DateTime dateBirth)
        {
            FirstName = firstN;
            SecondName = secondN;
            Patronymic = patr;
            DateBirthday = dateBirth;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length > 15 || String.IsNullOrEmpty(value))
                    throw new ArgumentException("First name must be less than 16 characters and not empty");
                else
                    firstName = value;
            }
        }
        public string SecondName
        {
            get => secondName;
            set
            {
                if (value.Length > 15 || String.IsNullOrEmpty(value))
                    throw new ArgumentException("Second name must be less than 16 characters and not empty");
                else
                    secondName = value;
            }
        }
        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (value.Length > 15 || String.IsNullOrEmpty(value))
                    throw new ArgumentException("Patronymic must be less than 16 characters and not empty");
                else
                    patronymic = value;
            }
        }
        public DateTime DateBirthday
        {
            get => dateBirthday;
            set
            {
                if (GetAge(value) < 0 || GetAge(value) > 140)
                    throw new ArgumentException("The age must be not negative and less than 141");
                else
                    dateBirthday = value;
            }
        }
        public int Age => GetAge(DateBirthday);  

        private int GetAge(DateTime dateBirth)
        {
            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - dateBirth.Year;

            if (dateNow.Month < dateBirth.Month || (dateNow.Month == dateBirth.Month && dateNow.Day < dateBirth.Day))
                year--;

            return year;
        }
        public virtual void ShowDetails()
        {
            Console.WriteLine("First name: {0}."
                + Environment.NewLine + "Second name: {1}"
                + Environment.NewLine + "Patronymic: {2}"
                + Environment.NewLine + "The date of birth: {3}"
                + Environment.NewLine + "Age: {4}", FirstName, SecondName, Patronymic, DateBirthday.ToShortDateString(), Age);
        }
    }
}
