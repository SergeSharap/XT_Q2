using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Menu
    {
        private int selectedItem;
        private int n;
        public void Choice()
        {
            User user = null;
            bool quit = false;
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
                        user = UserCreater();
                        break;
                    case 2:
                        if (user != null)
                            ChangeFirstName(ref user);
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (user != null)
                            ChangeSecondName(ref user);
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        if (user != null)
                            ChangePatronymic(ref user);
                        else
                        {
                            Console.WriteLine("You have not created user yet");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        if (user != null)
                            ChangeDateOfBirthday(ref user);
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
        private User UserCreater()
        {
            int year, month, day;
            string firstN, secondN, patr;

            Console.WriteLine("Please enter first name");
            firstN = Console.ReadLine();
            Console.WriteLine("Please enter second name");
            secondN = Console.ReadLine();
            Console.WriteLine("Please enter patronymic");
            patr = Console.ReadLine();

            year = Input("Please enter year of birth");
            month = Input("Please enter month of birth");
            day = Input("Please enter year of birth");

            try
            {
                User user = new User(firstN, secondN, patr, new DateTime(year, month, day));
                return user;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
                return null;
            }
        }
        private void ChangeFirstName(ref User user)
        {
            Console.WriteLine("Please enter first name");
            string firstN = Console.ReadLine();
            try
            {
                user.FirstName = firstN;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void ChangeSecondName(ref User user)
        {
            Console.WriteLine("Please enter second name");
            string secondN = Console.ReadLine();
            try
            {
                user.SecondName = secondN;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void ChangePatronymic(ref User user)
        {
            Console.WriteLine("Please enter patronymic");
            string patr = Console.ReadLine();
            try
            {
                user.Patronymic = patr;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private void ChangeDateOfBirthday(ref User user)
        {
            int year, month, day;
            year = Input("Please enter year of birth");
            month = Input("Please enter month of birth");
            day = Input("Please enter year of birth");
            try
            {
                user.DateBirthday = new DateTime(year, month, day);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }
        private int Input(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                bool isCorrectParse = Int32.TryParse(Console.ReadLine(), out n);

                if (isCorrectParse)
                    return n;
                else
                    Console.WriteLine("You entered not a number");
            }
        }
    }
}
