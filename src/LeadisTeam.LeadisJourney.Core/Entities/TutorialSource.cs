namespace LeadisTeam.LeadisJourney.Core.Entities {
    public class TutorialSource : Source {
        public virtual Tutorial Tutorial { get; set; }
        public virtual int TutorialId { get; set; }
    }
}