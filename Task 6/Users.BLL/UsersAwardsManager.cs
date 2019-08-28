using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Users.BLL
{
    public class UsersAwardsManager : IUsersAwardsManager
    {
        private static IUsersAwardsStorage UsersAwardsStorage;
        private static ISaver UsersAwardsSaver;
        private static IUsersManager UsersManager;
        private static IAwardsManager AwardsManager;

        public UsersAwardsManager(IUsersAwardsStorage usersAwardsStorage, ISaver userAwardSaver, IUsersManager usersManager, IAwardsManager awardsManager)
        {
            UsersAwardsStorage = usersAwardsStorage;
            UsersAwardsSaver = userAwardSaver;
            UsersManager = usersManager;
            AwardsManager = awardsManager;

            UsersManager.OnDeleted += DeleteAllByUser;
            AwardsManager.OnDeleted += DeleteAllByAward;
        }

        public bool AddAwardToUser(string name, string title)
        {
            User userForAdd = UsersManager.GetUser(name);
            Award awardForAdd = AwardsManager.GetAward(title);
            if (userForAdd == null || awardForAdd == null)
                return false;

            return UsersAwardsStorage.AddAwardToUser(userForAdd, awardForAdd);
        }

        public bool RemoveAwardFromUser(string name, string title)
        {
            if (UsersManager.GetUser(name) == null || AwardsManager.GetAward(title) == null)
                return false;

            return UsersAwardsStorage.RemoveAwardFromUser(name, title);
        }

        public ICollection<UsersAwards> GetAllList()
        {
            return UsersAwardsStorage.GetAllList();
        }

        public void DeleteAllByUser(string name)
        {
            UsersAwardsStorage.DeleteAllByUser(name);
        }

        public void DeleteAllByAward(string title)
        {
            UsersAwardsStorage.DeleteAllByAward(title);
        }

        public void Save()
        {
            UsersAwardsSaver.SaveToFile();
        }
    }
}
