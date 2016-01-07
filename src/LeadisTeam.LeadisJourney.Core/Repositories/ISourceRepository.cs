using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface ISourceRepository : IPersistRepository<Source>,
        IReadOnlyRepository<Source> {
        
    }
}