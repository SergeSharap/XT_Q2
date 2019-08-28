using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Users.Dependencies;

namespace Users.PL
{
    static class ConsolePL
    {
        private static IUsersManager UsersManager;
        private static IAwardsManager AwardsManager;
        private static IUsersAwardsManager UsersAwardsManager;

        static ConsolePL()
        {
            UsersManager = Dependencies.Dependencies.UsersManager;
            AwardsManager = Dependencies.Dependencies.AwardsManager;
            UsersAwardsManager = Dependencies.Dependencies.UsersAwardsManager;

        }
        
        public static void SelectAction()
        {
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
                        int year = Input("Please enter year of birth:");
                        int month = Input("Please enter month of birth:");
                        int day = Input("Please enter year of birth:");
                        try
                        {
                            Console.WriteLine(UsersManager.AddUser(name, new DateTime(year, month, day))
                            ? "User has been created."
                            : "User already exists.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        Console.WriteLine(UsersManager.DeleteUser(name)
                            ? "User has been deleted."
                            : "User is not found.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        Console.WriteLine(UsersAwardsManager.AddAwardToUser(name, title)
                            ? "Award has been added to user."
                            : "User or award are not found or user already has got the award.");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Enter name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        Console.WriteLine(UsersAwardsManager.RemoveAwardFromUser(name, title)
                            ? "Award has been deleted from user."
                            : "User or award are not found or user has not got the award.");
                        Console.ReadKey();
                        break;
                    case 5:
                        ShowAllUsersWithAwards(UsersManager.GetAllUsers(), UsersAwardsManager.GetAllList());
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        try
                        {
                            Console.WriteLine(AwardsManager.AddAward(title)
                            ? "Award has been created."
                            : "Award already exists.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.WriteLine("Enter title: ");
                        title = Console.ReadLine();
                        Console.WriteLine(AwardsManager.DeleteAward(title)
                        ? "Award has been deleted."
                        : "Award is not found.");
                        Console.ReadKey();
                        break;
                    case 8:
                        ShowAllAwards(AwardsManager.GetAllAwards());
                        Console.ReadKey();
                        break;
                    case 9:
                        quit = true;
                        UsersManager.Save();
                        AwardsManager.Save();
                        UsersAwardsManager.Save();
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
            foreach (var user in users)
            {
                var awards =
                    from uA in usersAwards
                    where uA.User.Name == user.Name
                    select uA.Award.Title;

                Console.WriteLine($"Name: {user.Name}. Date of birth: {user.DateOfBirth.ToShortDateString()}.");
                Console.WriteLine("List of awards: ");

                if (!awards.Any())
                {
                    Console.WriteLine("User have not got any awards");
                    continue;
                }
                foreach (var award in awards)
                {
                    Console.Write($"| {award} ");

                }
                Console.WriteLine(Environment.NewLine + new string('—', 50));
            }
        }

        private static void ShowAllAwards(ICollection<Award> awards)
        {
            foreach (var award in awards)
                Console.WriteLine($"Title: {award.Title}.");
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
