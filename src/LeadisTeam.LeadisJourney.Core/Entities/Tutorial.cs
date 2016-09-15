using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Tutorial : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<TutorialSource> Sources { get; set; }
        public virtual Exercice Exercice { get; set; }
    }
}