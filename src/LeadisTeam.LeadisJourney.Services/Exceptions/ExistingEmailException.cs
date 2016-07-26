using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Services.Exceptions
{
    public class ExistingEmailException : BusinessException
    {
        public ExistingEmailException() : base("Email address already linked to an account")
        {

        }
    }
}
