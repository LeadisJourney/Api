namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public class Source : IEntity
    {
        public virtual int Id { get; set; }
        // Type of source (video, pdf etc)
        public virtual string Type { get; set; }
        public virtual string Content { get; set; }

        // CONTENT ??? Une string qui donne le path ??
    }
}