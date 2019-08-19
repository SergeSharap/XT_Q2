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
    public class UsersAwardsStorage : IUsersAwardsStorage, ILoader, ISaver
    {
        private List<UsersAwards> usersAwards;
        
        public UsersAwardsStorage()
        {
            LoadFromFile();
        }

        public bool AddAwardToUser(User user, Award award)
        {
            if (usersAwards.Exists(uA => uA.Award.Title == award.Title && 
                                         user.Name == uA.User.Name))
                return false;

            usersAwards.Add(new UsersAwards(user, award));
            return true;
        }

        public bool RemoveAwardFromUser(string userName, string awardTitle)
        {
            UsersAwards usersAwardsForDelete = usersAwards.FirstOrDefault(uA => uA.Award.Title == awardTitle && 
                                                                                uA.User.Name == userName);
            if (usersAwardsForDelete == null)
                return false;

            usersAwards.Remove(usersAwardsForDelete);
            return true;
        }

        public ICollection<UsersAwards> GetAllList() => usersAwards;


        public void DeleteAllByUser(string name)
        {
            for (int i = 0; i < usersAwards.Count; i++)
            {
                if (usersAwards[i].User.Name == name)
                {
                    usersAwards.RemoveAt(i);
                    i--;
                }
            }
        }

        public void DeleteAllByAward(string title)
        {
            for (int i = 0; i < usersAwards.Count; i++)
            {
                if (usersAwards[i].Award.Title == title)
                {
                    usersAwards.RemoveAt(i);
                    i--;
                }
            }
        }

        public void LoadFromFile()
        {
            if (!File.Exists("UsersAwards.json"))
            {
                usersAwards = new List<UsersAwards>();
                return;
            }

            string usersAwardsForDeserialize = File.ReadAllText("UsersAwards.json");
            usersAwards = JsonConvert.DeserializeObject<List<UsersAwards>>(usersAwardsForDeserialize);
        }

        public void SaveToFile()
        {
            string usersAwardsForSerialize = JsonConvert.SerializeObject(usersAwards);
            File.WriteAllText("UsersAwards.json", usersAwardsForSerialize);
        }
    }
}
