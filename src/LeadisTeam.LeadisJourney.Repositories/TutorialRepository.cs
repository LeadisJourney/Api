using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using NHibernate.Linq;
using NHibernate.Persister.Entity;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class TutorialRepository : Repository<Tutorial>, ITutorialRepository {
        public TutorialRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }

        public IQueryable<Tutorial> GetAllWithSources()
        {
            return this.All().Fetch(m => m.Sources);
        }

        public Tutorial GetWithSource(int id)
        {
            return this.All().Fetch(m => m.Sources).FirstOrDefault(m => m.Id == id);
        }
    }
}