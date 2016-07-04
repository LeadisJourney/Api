using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class UserExperienceRepository : Repository<UserExperience>, IUserExperienceRepository {
        public UserExperienceRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }
}