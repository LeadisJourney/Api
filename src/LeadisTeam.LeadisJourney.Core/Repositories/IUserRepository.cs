using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
	public interface IUserRepository : IPersistRepository<User>,
		IReadOnlyRepository<User> {
		 
	}
}