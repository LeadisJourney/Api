using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Group : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Account> Admins { get; set; }
        public virtual IList<Account> Members { get; set;  }
    }
}