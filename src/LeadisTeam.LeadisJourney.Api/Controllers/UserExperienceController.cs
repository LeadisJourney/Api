using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadisTeam.LeadisJourney.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class UserExperienceController : Controller
    {
        private readonly IUserExperienceService _userExperience;

        public UserExperienceController(IUserExperienceService userExperience)
        {
            _userExperience = userExperience;
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<UserExperienceModel.Response> ManageCode([FromBody] UserExperienceModel res)
        {
            var userId = User.Claims.First(c => c.Type.Equals("UserId")).Value;
            var response = await _userExperience.ManageCodeAsync(res.Code, res.Language, res.RequestId, userId, res.Type);
            return new UserExperienceModel.Response()
            {
                Status = response.Status,
                Errors = response.Errors,
                Warnings = response.Warnings,
                Result = response.Result
            };
        }
    }
}
