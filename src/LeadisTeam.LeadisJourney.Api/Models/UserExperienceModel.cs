using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Api.Models
{
    public class UserExperienceModel
    {
        public string Code { get; set; }
        public string Language { get; set; } // C or C++
        public string Type { get; set; } // Compilation or Execution
        public string RequestId { get; set; } // Generée par Thomas
        public string Exercise { get; set; }
        public class Response
        {
            public string Status { get; set; }
            public ICollection<string> Errors { get; set; }
            public ICollection<string> Warnings { get; set; }
            public string Result { get; set; }
        }
    }
}
