using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface IAccountRepository : IPersistRepository<Account>,
		IReadOnlyRepository<Account> {
         
    }
}