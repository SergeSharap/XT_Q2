using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUsersManager
    {
        event Action<string> OnDeleted;

        User GetUser(string name);

        bool AddUser(String name, DateTime dateOfBirth);

        bool DeleteUser(String name);

        ICollection<User> GetAllUsers();

        void Save();
    }
}
