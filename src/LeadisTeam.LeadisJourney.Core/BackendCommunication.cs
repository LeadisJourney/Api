using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Configuration;
using Orion.ApiClientLight;

namespace LeadisTeam.LeadisJourney.Core
{
    public class BackendCommunication {
        private readonly ServerConfiguration _serverConfigurations;

        public BackendCommunication(ServerConfiguration serverConfigurations)
        {
            _serverConfigurations = serverConfigurations;
        }

        public async Task<StatusExerciceModel> ToCompilatorAsync(string userId, string requestId, string code, string language, string type, string exercise) {
            string url = _serverConfigurations.Url;
            object data = new {
                UserId = userId,
                RequestId = requestId,
                Code = code,
                Language = language,
                Type = type,
                Exercise = exercise
            };

            var jsonApiClientLight = new JsonApiClientLight();
            var response = await jsonApiClientLight.PostAsync<StatusExerciceModel>(url, data);
            StatusExerciceModel model = response.Response;
            return model;
        }
    }
}
