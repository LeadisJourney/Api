using System.Collections.Generic;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface ITutorialService
    {
        Tutorial[] GetAll();
        Tutorial GetById(int id);
        void Create(string title, IEnumerable<TutorialSource> tutorialSources, int exerciceId);
        void Update(int id, string title, int exerciceId, IEnumerable<TutorialSource> tutorialSources);
        void Desactivate(int id);
    }
}
