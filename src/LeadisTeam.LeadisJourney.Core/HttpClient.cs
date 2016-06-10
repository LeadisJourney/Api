using System.Collections.Generic;
using System.Threading.Tasks;
using Orion.ApiClientLight;

namespace LeadisTeam.LeadisJourney.Core
{
    public class HttpClient {

        public async Task<StatusExerciceModel> ToCompilator(int UserId, int RequestId, string Code, string Language, string Type) {
            string url = "http://163.5.84.111:8443/v0.1/ce/status";
            object data = new {
                UserId = UserId,
                RequestId = RequestId,
                Code = Code,
                Language = Language,
                Type = Type
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
