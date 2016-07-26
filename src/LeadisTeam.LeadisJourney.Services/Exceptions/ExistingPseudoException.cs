using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Services.Exceptions
{
    public class ExistingPseudoException : BusinessException
    {
        public ExistingPseudoException() : base("Pseudo already taken")
        {
            
        }
    }
}
