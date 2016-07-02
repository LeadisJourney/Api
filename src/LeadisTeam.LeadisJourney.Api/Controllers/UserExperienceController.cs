using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadisTeam.LeadisJourney.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class UserExperienceController : Controller
    {
         [HttpPost]
         [Authorize("Bearer")]
         public UserExperienceModel.Response ManageCode([FromBody] UserExperienceModel res)
         {
             var userId = User.Claims.First(c => c.Type.Equals("UserId")).Value;
            
            return new UserExperienceModel.Response()
             {
                 Status = "OK",
                 Errors = null,
                 Warnings = null,
                 Result = "je fonctionne"
             };
         }
     }
}
