using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public interface IUsersStorage
    {
        User GetUser(string name);
        bool AddUser(User user);
        bool DeleteUser(string name);
        ICollection<User> GetAllUsers();
    }
}