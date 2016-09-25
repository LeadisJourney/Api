using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface IExerciceRepository : IPersistRepository<Exercice>,
        IReadOnlyRepository<Exercice> {

        IQueryable<Exercice> GetAllWithSources();
        Exercice GetWithSource(int id);
    }
}