using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
    public interface ITutorialRepository : IPersistRepository<Tutorial>,
        IReadOnlyRepository<Tutorial>
    {
        IQueryable<Tutorial> GetAllWithSources();
        Tutorial GetWithSource(int id);
    }
}