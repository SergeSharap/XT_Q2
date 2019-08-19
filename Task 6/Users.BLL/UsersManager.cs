using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Users.DALTextFiles;
using Users.Dependencies;

namespace Users.BLL
{
    public static class UsersManager
    {
        private static IUsersStorage UsersStorage => Dependencies.Dependencies.UsersStorage;

        public static User GetUser(string name)
        {
            return UsersStorage.GetUser(name);
        }

        public static bool AddUser(String name, DateTime dateOfBirth)
        {
            return UsersStorage.AddUser(new User(name, dateOfBirth));
        }

        public static bool DeleteUser(String name)
        {
            if (!UsersStorage.DeleteUser(name)) return false;
            UsersAwardsManager.DeleteAllByUser(name);
            return true;
        }

        public static ICollection<User> GetAllUsers() => UsersStorage.GetAllUsers();
    }
}
