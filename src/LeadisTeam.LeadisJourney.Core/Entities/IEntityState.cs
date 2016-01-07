using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadisTeam.LeadisJourney.Core.Entities
{
    public interface IEntityState {
        EntityState EntityState { get; set; }
    }
}
