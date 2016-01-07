using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface IGroupRepository : IPersistRepository<Group>,
        IReadOnlyRepository<Group> {
        
    }
}