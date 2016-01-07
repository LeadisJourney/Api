using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface ITutorialRepository : IPersistRepository<Tutorial>,
        IReadOnlyRepository<Tutorial> {
        
    }
}