using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Services.Exceptions
{
    public class ExerciceNotFoundException : BusinessException
    {
        public ExerciceNotFoundException() : base("Exercice not found")
        {
            
        }
    }
}
