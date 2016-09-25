using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class CreateExerciceModel
    {
        public string Title { get; set; }
        public int Position { get; set; }
        public IEnumerable<ExerciceSourceModel> Sources { get; set; }
    }
}
