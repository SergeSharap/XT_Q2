using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IAwardsManager
    {
        event Action<string> OnDeleted;

        Award GetAward(string title);

        bool AddAward(string title);

        bool DeleteAward(string title);

        ICollection<Award> GetAllAwards();

        void Save();
    }
}
