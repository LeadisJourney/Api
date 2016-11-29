using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Tutorial : IEntity, IEntityState
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<TutorialSource> Sources { get; set; }
        public virtual Exercice Exercice { get; set; }
        public virtual int ExerciceId { get; set; }
        public virtual EntityState EntityState { get; set; }
    }
}