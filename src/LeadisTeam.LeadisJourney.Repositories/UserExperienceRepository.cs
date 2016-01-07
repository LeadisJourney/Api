using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class UserExperienceRepository : Repository<UserExperience>, IUserExperienceRepository {
        public UserExperienceRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}