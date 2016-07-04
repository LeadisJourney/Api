using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories {
	public class UserRepository : Repository<User>, IUserRepository {
		public UserRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
		}
	}
}