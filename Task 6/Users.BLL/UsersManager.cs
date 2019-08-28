using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Users.BLL
{
    public class UsersManager : IUsersManager
    {
        private static IUsersStorage UsersStorage;
        private static ISaver UsersSaver;

        public event Action<string> OnDeleted; 

        public UsersManager(IUsersStorage usersStorage, ISaver userSaver)
        {
            UsersStorage = usersStorage;
            UsersSaver = userSaver;
        }

        public User GetUser(string name)
        {
            return UsersStorage.GetUser(name);
        }

        public bool AddUser(String name, DateTime dateOfBirth)
        {
            return UsersStorage.AddUser(new User(name, dateOfBirth));
        }

        public bool DeleteUser(String name)
        {
            if (!UsersStorage.DeleteUser(name)) return false;
            OnDeleted?.Invoke(name);
            return true;
        }

        public ICollection<User> GetAllUsers() => UsersStorage.GetAllUsers();

        public void Save()
        {
            UsersSaver.SaveToFile();
        }
    }
}
