using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface IUserExperienceRepository : IPersistRepository<UserExperience>,
        IReadOnlyRepository<UserExperience> {
        
    }
}