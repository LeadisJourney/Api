using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Api.Models;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Repositories.NHibernate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadisTeam.LeadisJourney.Api.Controllers {
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
    [Route("v0.1/api/[controller]")]
    public class UserExperienceController : ApiController
    {
        private readonly IUserExperienceService _userExperience;

        public UserExperienceController(IScopeFactory scopeFactory, IUserExperienceService userExperience) : base(scopeFactory)
        {
            _userExperience = userExperience;
        }

        [HttpPost]
        public async Task<UserExperienceModel.Response> ManageCode([FromBody] UserExperienceModel res)
        {
            var userId = User.Claims.First(c => c.Type.Equals("UserId")).Value;
            var response = await _userExperience.ManageCodeAsync(res.Code, res.Language, res.RequestId, userId, res.Type, res.Exercise);
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
