using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository {
        public AccountRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }
}
