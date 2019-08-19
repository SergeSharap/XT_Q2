using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUsersAwardsStorage
    {
        bool AddAwardToUser(User user, Award award);
        bool RemoveAwardFromUser(string userName, string awardTitle);
        ICollection<UsersAwards> GetAllList();
        void DeleteAllByUser(string name);
        void DeleteAllByAward(string title);

    }
}
