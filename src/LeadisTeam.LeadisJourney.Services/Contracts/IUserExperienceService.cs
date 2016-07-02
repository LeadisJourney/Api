using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface IUserExperienceService
    {
        Task<StatusExerciceModel> ManageCode(string code, string language, string requestId, string userId, string type);
    }
}
