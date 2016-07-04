using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Core
{
    public class StatusExerciceModel {
    
        public string Status { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Warnings { get; set; }
        public string Result { get; set; }
    }
}