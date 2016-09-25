using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class CreateTutorialModel
    {
        public string Title { get; set; }
        public IEnumerable<TutorialSourceModel> Sources { get; set; }
        public string Type { get; set; }
        public int ExerciceId { get; set; }
    }
}
