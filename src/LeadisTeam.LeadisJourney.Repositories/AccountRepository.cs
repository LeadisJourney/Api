using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository {
        public AccountRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}
