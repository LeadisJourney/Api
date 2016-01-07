using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Repositories {
    public class ExerciceRepository : Repository<Exercice>, IExerciceRepository {
        public ExerciceRepository(DbContext dbContext) : base(dbContext) {
        }
    }
}