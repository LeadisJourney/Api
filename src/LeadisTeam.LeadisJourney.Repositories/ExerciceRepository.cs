using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using NHibernate.Linq;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class ExerciceRepository : Repository<Exercice>, IExerciceRepository {
        public ExerciceRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
        public IQueryable<Exercice> GetAllWithSources()
        {
            return this.All().Fetch(m => m.Sources);
        }

        public Exercice GetWithSource(int id)
        {
            return this.All().Fetch(m => m.Sources).FirstOrDefault(m => m.Id == id);
        }
    }
}