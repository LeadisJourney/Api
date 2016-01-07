using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Repositories {
	public class UserRepository : Repository<User>, IUserRepository {
		public UserRepository(DbContext dbContext) : base(dbContext) {
		}
	}
}