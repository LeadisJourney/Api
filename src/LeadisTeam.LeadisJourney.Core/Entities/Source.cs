namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Source : IEntity, IEntityState
    {
        public virtual int Id { get; set; }
        // Type of source (video, pdf etc)
        public virtual string Type { get; set; }
        public virtual string Content { get; set; }
        public virtual EntityState EntityState { get; set; }
    }
}