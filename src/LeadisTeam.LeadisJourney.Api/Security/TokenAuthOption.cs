using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens;

namespace LeadisTeam.LeadisJourney.Api.Security
{
    public class TokenAuthOption
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public SecurityKey Key { get; set; }
    }
}