using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface IUserExperienceService
    {
        Task<StatusExerciceModel> ManageCodeAsync(string code, string language, string requestId, string userId, string type, string exercise);
    }
}
