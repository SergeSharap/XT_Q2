using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Users.BLL
{
    public static class Saver
    {
        private static ISaver AwardsSaver => Dependencies.Dependencies.AwardsSaver;
        private static ISaver UsersSaver => Dependencies.Dependencies.UsersSaver;
        private static ISaver UsersAwardsSaver => Dependencies.Dependencies.UsersAwardsSaver;

        public static void SaveAll()
        {
            UsersSaver.SaveToFile();
            AwardsSaver.SaveToFile();
            UsersAwardsSaver.SaveToFile();
        }
    }
}
