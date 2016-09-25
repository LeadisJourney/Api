using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Services.Exceptions
{
    public class ExistingTitleException : BusinessException
    {
        public ExistingTitleException() : base("This title is already taken")
        {
            
        }
    }
}
