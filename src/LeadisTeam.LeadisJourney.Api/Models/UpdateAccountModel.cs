using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class UpdateAccountModel {
        public string Email { get; set; }
        public string Password { get; set; }
        
        //Update User infos
        public string Name { get; set; }
        public string FirstName { get; set; }

    }
}
