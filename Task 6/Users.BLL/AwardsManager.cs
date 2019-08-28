using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Users.BLL
{
    public class AwardsManager : IAwardsManager
    {
        private static IAwardsStorage AwardsStorage;
        private static ISaver AwardsSaver;

        public event Action<string> OnDeleted; 

        public AwardsManager(IAwardsStorage awardsStorage, ISaver awardsSaver)
        {
            AwardsStorage = awardsStorage;
            AwardsSaver = awardsSaver;
        }

        public Award GetAward(string title)
        {
            return AwardsStorage.GetAward(title);
        }

        public bool AddAward(string title)
        {
            return AwardsStorage.AddAward(title);
        }

        public bool DeleteAward(string title)
        {
            if (!AwardsStorage.DeleteAward(title)) return false;
            OnDeleted?.Invoke(title);
            return true;
        }

        public ICollection<Award> GetAllAwards() => AwardsStorage.GetAllAwards();

        public void Save()
        {
            AwardsSaver.SaveToFile();
        }
    }
}
