using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Exercice : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual ExerciceSource Source { get; set; }
        public virtual int Position { get; set; }
        //Associated tutorial(s)
        public virtual IList<Tutorial> Tutorials { get; set; }
        //The potential help docs
        public virtual IList<HelpSource> Helps { get; set; }
    }
}