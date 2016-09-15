using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface ITutorialService
    {
        Tutorial[] GetAll();
        Tutorial GetById(int id);
    }
}
