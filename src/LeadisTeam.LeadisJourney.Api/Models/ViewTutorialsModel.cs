using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class ViewTutorialsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<TutorialSourceModel> Sources { get; set; }
    }
}
