using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class LoginAccountModel {
        public string Email { get; set; }
        public string Password { get; set; }
        public class Response {
            public string Token { get; set; }
        }
    }
}
