using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;

namespace LeadisTeam.LeadisJourney.Services
{
    public class TutorialService : ITutorialService{
        private readonly ITutorialRepository _tutorialRepository;

        public TutorialService(ITutorialRepository tutorialRepository)
        {
            _tutorialRepository = tutorialRepository;
        }

        public Tutorial[] GetAll()
        {

            return _tutorialRepository.GetAllWithSources().ToArray();
        }

        public Tutorial GetById(int id)
        {
            return _tutorialRepository.GetWithSource(id);
        }
    }
}
