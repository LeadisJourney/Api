using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class ExerciceRepository : Repository<Exercice>, IExerciceRepository {
        public ExerciceRepository(IScopeFactory scopeFactory) : base(scopeFactory) {
        }
    }
}