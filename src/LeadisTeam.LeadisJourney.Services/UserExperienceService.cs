using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Core;
using LeadisTeam.LeadisJourney.Core.Configuration;
using Microsoft.Extensions.Options;

namespace LeadisTeam.LeadisJourney.Services
{
    public class UserExperienceService : IUserExperienceService
    {
        private readonly ServerConfiguration _serverConfigurations;

        public UserExperienceService(IOptions<ServerConfiguration> serverConfigurations)
        {
            _serverConfigurations = serverConfigurations?.Value;
        }

        public Task<StatusExerciceModel> ManageCodeAsync(string code, string language, string requestId, string userId, string type, string exercise) //userId = Token de la session user
        {
            var backendCommunication = new BackendCommunication(_serverConfigurations);
            return backendCommunication.ToCompilatorAsync(userId, requestId, code, language, type, exercise);
        }
    }
}
