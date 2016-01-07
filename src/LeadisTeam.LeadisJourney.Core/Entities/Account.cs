using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Account : IEntity, IEntityState
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Pseudo { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<Group> Group { get; set; }
        public virtual User User { get; set; }
        public virtual bool IsOwner { get; set; }
        public virtual IList<UserExperience> UserExperience { get; set; }
        public virtual EntityState EntityState { get; set; }
    }
}
