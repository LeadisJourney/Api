using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadisTeam.LeadisJourney.Api.Controllers
{
    [EnableCors("AllowAll")]
    [Route("v0.1/api/[controller]")]
    public class UserExperienceController : Controller
    {
        /* [HttpPost]
         [Authorize("Bearer")]
         public UserExperienceModel.Response ManageCode([FromBody] UserExperienceModel res)
         {

         }
     }

     public class UserExperienceModel
     {
         public 
         public class Response
         {
             public string Status { get; set; }
             public ICollection<string> Errors { get; set; }
             public ICollection<string> Warnings { get; set; }
             public string Result { get; set; }
         }*/
    }
}
