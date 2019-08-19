using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Users.Dependencies;

namespace Users.BLL
{
    public static class UsersAwardsManager
    {
        private static IUsersAwardsStorage UsersAwardsStorage => Dependencies.Dependencies.UsersAwardsStorage;

        public static bool AddAwardToUser(string name, string title)
        {
            User userForAdd = UsersManager.GetUser(name);
            Award awardForAdd = AwardsManager.GetAward(title);
            if (userForAdd == null || awardForAdd == null)
                return false;

            return UsersAwardsStorage.AddAwardToUser(userForAdd, awardForAdd);
        }

        public static bool RemoveAwardFromUser(string name, string title)
        {
            if (UsersManager.GetUser(name) == null || AwardsManager.GetAward(title) == null)
                return false;

            return UsersAwardsStorage.RemoveAwardFromUser(name, title);
        }

        public static ICollection<UsersAwards> GetAllList()
        {
            return UsersAwardsStorage.GetAllList();
        }

        public static void DeleteAllByUser(string name)
        {
            UsersAwardsStorage.DeleteAllByUser(name);
        }

        public static void DeleteAllByAward(string title)
        {
            UsersAwardsStorage.DeleteAllByAward(title);
        }

    }
}
