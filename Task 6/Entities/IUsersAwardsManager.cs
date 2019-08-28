using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUsersAwardsManager
    {
        bool AddAwardToUser(string name, string title);

        bool RemoveAwardFromUser(string name, string title);

        ICollection<UsersAwards> GetAllList();

        void DeleteAllByUser(string name);

        void DeleteAllByAward(string title);

        void Save();
    }
}
