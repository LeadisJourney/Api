using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class GroupRepository : Repository<Group>, IGroupRepository {
        public GroupRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }
}