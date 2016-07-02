using System.Collections.Generic;
using System.Threading.Tasks;
using Orion.ApiClientLight;

namespace LeadisTeam.LeadisJourney.Core
{
    public class HttpClient {

        public async Task<StatusExerciceModel> ToCompilator(string userId, string requestId, string code, string language, string type) {
            string url = "http://163.5.84.111:8443/v0.1/ce/status";
            object data = new {
                UserId = userId,
                RequestId = requestId,
                Code = code,
                Language = language,
                Type = type
            };

            var jsonApiClientLight = new JsonApiClientLight();
            var response = await jsonApiClientLight.PostAsync<StatusExerciceModel>(url, data, null);
            StatusExerciceModel model = response.Response;
            return model;
        }
    }

    public class StatusExerciceModel {
    
        public string Status { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Warnings { get; set; }
        public string Result { get; set; }
}
}
