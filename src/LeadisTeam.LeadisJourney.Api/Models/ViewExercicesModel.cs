using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class ViewExercicesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Position { get; set; }
        public IEnumerable<ExerciceSourceModel> Sources { get; set; }
    }
}
