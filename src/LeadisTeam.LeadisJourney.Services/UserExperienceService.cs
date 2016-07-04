using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Core;

namespace LeadisTeam.LeadisJourney.Services
{
    public class UserExperienceService : IUserExperienceService
    {
        public Task<StatusExerciceModel> ManageCodeAsync(string code, string language, string requestId, string userId, string type) //userId = Token de la session user
        {
            var backendCommunication = new BackendCommunication();
            return backendCommunication.ToCompilatorAsync(userId, requestId, code, language, type);
        }
    }
}
