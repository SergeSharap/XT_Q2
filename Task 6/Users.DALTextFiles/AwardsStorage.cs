using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Newtonsoft.Json;

namespace Users.DALTextFiles
{
    public class AwardsStorage : IAwardsStorage, ILoader, ISaver
    {
        private List<Award> awards;

        public AwardsStorage()
        {
            LoadFromFile();
        }

        public Award GetAward(string title)
        {
            return awards.FirstOrDefault(a => title == a.Title);
        }

        public bool AddAward(string title)
        {
            if (awards.Exists(a => title == a.Title))
                return false;

            awards.Add(new Award(title));
            return true;
        }

        public bool DeleteAward(string title)
        {
            Award awardForDelete = awards.FirstOrDefault(a => title == a.Title);
            if (awardForDelete == null)
                return false;

            awards.Remove(awardForDelete);
            return true;
        }

        public ICollection<Award> GetAllAwards() => awards;

        public void LoadFromFile()
        {
            if (!File.Exists("Awards.json"))
            {
                awards = new List<Award>();
                return;
            }

            string awardsForDeserialize = File.ReadAllText("Awards.json");
            awards = JsonConvert.DeserializeObject<List<Award>>(awardsForDeserialize);
        }

        public void SaveToFile()
        {
            string awardsForSerialize = JsonConvert.SerializeObject(awards);
            File.WriteAllText("Awards.json", awardsForSerialize);
        }
    }
}
