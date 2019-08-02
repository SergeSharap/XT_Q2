using System;

namespace _2._3
{
    public class Menu
    {
        private int selectedItem;
        private User user = null;
        private bool quit = false;

        public void Choice()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" + Environment.NewLine);
                Console.WriteLine("1. Create user"
                    + Environment.NewLine + "2. Change first name"
                    + Environment.NewLine + "3. Change second name"
                    + Environment.NewLine + "4. Change patronymic"
                    + Environment.NewLine + "5. Change date of birthday"
                    + Environment.NewLine + "6. Show details"
                    + Environment.NewLine + "7. Quit"
                    );

                
                Int32.TryParse(Console.ReadLine(), out selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        UserCreater();
                        break;
                    case 2:
                        if (user != null)
                            ChangeFirstName();
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (user != null)
                            ChangeSecondName();
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        if (user != null)
                            ChangePatronymic();
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        if (user != null)
                            ChangeDateOfBirthday();
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        if (user != null)
                        {
                            user.ShowDetails();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        quit = true;
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }
        private void UserCreater()
        {
            Console.WriteLine("Please enter first name");
            string firstN = Console.ReadLine();
            Console.WriteLine("Please enter second name");
            string secondN = Console.ReadLine();
            Console.WriteLine("Please enter patronymic");
            string patr = Console.ReadLine();

            int year = Input("Please enter year of birth");
            int month = Input("Please enter month of birth");
            int day = Input("Please enter year of birth");

            try
            {
                user = new User(firstN, secondN, patr, new DateTime(year, month, day));

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private void ChangeFirstName()
        {
            Console.WriteLine("Please enter first name");
            string firstN = Console.ReadLine();
            try
            {
                user.FirstName = firstN;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private void ChangeSecondName()
        {
            Console.WriteLine("Please enter second name");
            string secondN = Console.ReadLine();
            try
            {
                user.SecondName = secondN;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private void ChangePatronymic()
        {
            Console.WriteLine("Please enter patronymic");
            string patr = Console.ReadLine();
            try
            {
                user.Patronymic = patr;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private void ChangeDateOfBirthday()
        {
            int year = Input("Please enter year of birth");
            int month = Input("Please enter month of birth");
            int day = Input("Please enter year of birth");
            try
            {
                user.DateBirthday = new DateTime(year, month, day);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private int Input(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = Int32.TryParse(Console.ReadLine(), out int n);

                if (isCorrectParse)
                    return n;
                else
                    Console.WriteLine("You entered not a number");
            }
        }
    }
}
