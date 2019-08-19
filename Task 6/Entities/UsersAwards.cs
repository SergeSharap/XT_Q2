using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UsersAwards
    {


        public UsersAwards(User user, Award award)
        {
            User = user;
            Award = award;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public User User { get; private set; }
        public Award Award { get; private set; }
    }
}
