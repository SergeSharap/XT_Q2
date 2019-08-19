using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Users.Dependencies;

namespace Users.BLL
{
    public static class AwardsManager
    {
        private static IAwardsStorage AwardsStorage => Dependencies.Dependencies.AwardsStorage;

        public static Award GetAward(string title)
        {
            return AwardsStorage.GetAward(title);
        }

        public static bool AddAward(string title)
        {
            return AwardsStorage.AddAward(title);
        }

        public static bool DeleteAward(string title)
        {
            if (!AwardsStorage.DeleteAward(title)) return false;
            UsersAwardsManager.DeleteAllByAward(title);
            return true;
        }

        public static ICollection<Award> GetAllAwards() => AwardsStorage.GetAllAwards();
    }
}
