namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Tutorial : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual TutorialSource Source { get; set; }
        public virtual Exercice Exercice { get; set; }
    }
}