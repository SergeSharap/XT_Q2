using System;
using System.Collections.Generic;
using Entities;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Users.DALTextFiles
{
    public class UsersStorage : IUsersStorage, ILoader, ISaver
    {
        private List<User> users;

        public UsersStorage()
        {
            LoadFromFile();
        }

        public User GetUser(string name)
        {
            return users.FirstOrDefault(u => name == u.Name);
        }

        public bool AddUser(User user)
        {
            if (users.Exists(u => user.Name == u.Name))
                return false;

            users.Add(user);
            return true;
        }

        public bool DeleteUser(string name)
        {
            User userForDelete = users.FirstOrDefault(u => name == u.Name);
            if (userForDelete == null)
                return false;

            users.Remove(userForDelete);
            return true;
        }

        public ICollection<User> GetAllUsers() => users;

        public void LoadFromFile()
        {
            if (!File.Exists("Users.json"))
            {
                users = new List<User>();
                return;
            }

            string usersForDeserialize = File.ReadAllText("Users.json");
            users = JsonConvert.DeserializeObject<List<User>>(usersForDeserialize);
        }

        public void SaveToFile()
        {
            string usersForSerialize = JsonConvert.SerializeObject(users);
            File.WriteAllText("Users.json", usersForSerialize);
        }
    }
}
