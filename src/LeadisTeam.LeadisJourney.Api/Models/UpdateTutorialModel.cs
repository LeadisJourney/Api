using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class UpdateTutorialModel
    {
        public string Title { get; set; }
        public IEnumerable<TutorialSourceModel> Sources { get; set; }
        public int ExerciceId { get; set; }
    }
}
