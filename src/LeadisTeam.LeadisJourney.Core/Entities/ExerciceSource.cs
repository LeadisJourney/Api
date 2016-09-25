namespace LeadisTeam.LeadisJourney.Core.Entities {
    public class ExerciceSource : Source {
        public virtual Exercice Exercice { get; set; }
        public virtual int ExerciceId { get; set; }
    }
}