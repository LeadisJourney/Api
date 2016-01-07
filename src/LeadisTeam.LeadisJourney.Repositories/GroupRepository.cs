using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class GroupRepository : Repository<Group>, IGroupRepository {
        public GroupRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}