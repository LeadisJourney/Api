using System.Threading.Tasks;
using Orion.ApiClientLight;

namespace LeadisTeam.LeadisJourney.Core
{
    public class BackendCommunication {

        public async Task<StatusExerciceModel> ToCompilatorAsync(string userId, string requestId, string code, string language, string type, string exercise) {
            string url = "http://163.5.84.111:8443/v0.1/ce/status";
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
