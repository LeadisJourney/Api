using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class TutorialRepository : Repository<Tutorial>, ITutorialRepository {
        public TutorialRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }
}