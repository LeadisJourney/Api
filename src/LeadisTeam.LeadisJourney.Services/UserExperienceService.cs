using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Core;

namespace LeadisTeam.LeadisJourney.Services
{
    public class UserExperienceService : IUserExperienceService
    {
        public async Task<StatusExerciceModel> ManageCode(string code, string language, string requestId, string userId, string type) //userId = Token de la session user
        {
            StatusExerciceModel response = await new HttpClient().ToCompilator(userId, requestId, code, language, type);
            return response;
        }
    }
}
