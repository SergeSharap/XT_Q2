using System;
using Users.DALTextFiles;
using Entities;
using Users.BLL;

namespace Users.Dependencies
{
    public static class Dependencies
    {
        public static IUsersStorage UsersStorage { get; } 
        public static IAwardsStorage AwardsStorage { get; }
        public static IUsersAwardsStorage UsersAwardsStorage { get; }

        public static ISaver UsersSaver { get; }
        public static ISaver AwardsSaver { get; }
        public static ISaver UsersAwardsSaver { get; }

        public static IUsersManager UsersManager { get; }
        public static IAwardsManager AwardsManager { get; }
        public static IUsersAwardsManager UsersAwardsManager { get; }

        static Dependencies()
        {
            UsersStorage usersStorage = new UsersStorage();
            AwardsStorage awardsStorage = new AwardsStorage();
            UsersAwardsStorage usersAwardsStorage = new UsersAwardsStorage();

            UsersStorage = usersStorage;
            AwardsStorage = awardsStorage;
            UsersAwardsStorage = usersAwardsStorage;

            UsersSaver = usersStorage;
            AwardsSaver = awardsStorage;
            UsersAwardsSaver = usersAwardsStorage;

            UsersManager = new UsersManager(UsersStorage, UsersSaver);
            AwardsManager = new AwardsManager(AwardsStorage, AwardsSaver);
            UsersAwardsManager = new UsersAwardsManager(UsersAwardsStorage, UsersAwardsSaver, UsersManager, AwardsManager);
        }
    }
}