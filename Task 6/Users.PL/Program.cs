using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Entities;
using Users.BLL;

namespace Users.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectAction();
        }

        static void SelectAction()
        {
            int year, month, day;
            string name, title;
            bool quit = false;
            do
            {
                Console.Clear();

                Console.WriteLine("Select action:" 
                                  + Environment.NewLine + "1. Create user"
                                  + Environment.NewLine + "2. Delete user"
                                  + Environment.NewLine + "3. Reward user"
                                  + Environment.NewLine + "4. Remove award from user"
                                  + Environment.NewLine + "5. Show all users"
                                  + Environment.NewLine + "6. Add award"
                                  + Environment.NewLine + "7. Delete award"
                                  + Environment.NewLine + "8. Show all awards"
                                  + Environment.NewLine + "9. Quit"
                );

                int.TryParse(Console.ReadLine(), out int selectedItem);

                switch (selectedItem)
                {
                    case 1:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        year = Input("Please enter year of birth:");
                        month = Input("Please enter month of birth:");
                        day = Input("Please enter year of birth:");
                        try
                        {
                            UsersManager.AddUser(name, new DateTime(year, month, day));
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        UsersManager.DeleteUser(name);
                        break;
                    case 3:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        UsersAwardsManager.AddAwardToUser(name, title);
                        break;
                    case 4:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        UsersAwardsManager.RemoveAwardFromUser(name, title);
                        break;
                    case 5:
                        ShowAllUsersWithAwards(UsersManager.GetAllUsers(), UsersAwardsManager.GetAllList());
                        break;
                    case 6:
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        AwardsManager.AddAward(title);
                        break;
                    case 7:
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        AwardsManager.DeleteAward(title);
                        break;
                    case 8:
                        ShowAllAwards(AwardsManager.GetAllAwards());
                        break;
                    case 9:
                        quit = true;
                        Saver.SaveAll();
                        break;
                    default:
                        break;
                }
            } while (!quit);
        }

        private static void ShowAllUsers(ICollection<User> users)
        {
            foreach (var user in users)
                Console.WriteLine($"Name: {user.Name}. Date of birth: {user.DateOfBirth.ToShortDateString()}.");
        }

        private static void ShowAllUsersWithAwards(ICollection<User> users, ICollection<UsersAwards> usersAwards)
        {
            var usersGroupBy = usersAwards.GroupBy(uA => uA.User.Name);
            var usersWithAwards = 
                from u in users
                join uG in usersGroupBy
                    on u.Name equals uG.Key into uAwards
                from sub in uAwards.DefaultIfEmpty()
                select new
                {
                    Name = u.Name,
                    DateOfBirth = u.DateOfBirth,
                    listOfAwards = sub
                };


            foreach (var userWithAwards in usersWithAwards)
            {
                Console.WriteLine($"Name: {userWithAwards.Name}. Date of birth: {userWithAwards.DateOfBirth.ToShortDateString()}.");
                Console.WriteLine("List of awards: ");

                if (userWithAwards.listOfAwards == null)
                {
                    Console.WriteLine("User have not got any awards");
                    continue;
                }
                foreach (var award in userWithAwards.listOfAwards)
                {
                    Console.Write($"| {award.Award.Title} ");
                }

                Console.WriteLine(Environment.NewLine + new string('—', 50));
            }

            Console.ReadLine();
        }

        private static void ShowAllAwards(ICollection<Award> awards)
        {
            foreach (var award in awards)
                Console.WriteLine($"Title: {award.Title}.");

            Console.ReadLine();
        }

        private static int Input(string message)
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