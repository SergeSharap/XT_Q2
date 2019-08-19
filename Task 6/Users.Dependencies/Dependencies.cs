using System;
using Users.DALTextFiles;
using Entities;

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
        }

    }
}