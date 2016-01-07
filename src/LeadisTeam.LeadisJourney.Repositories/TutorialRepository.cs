using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class TutorialRepository : Repository<Tutorial>, ITutorialRepository {
        public TutorialRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}