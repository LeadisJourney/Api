using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface IGroupService {
        void Create(string name, int adminId);
        void AddUser(List<int> accountsId, int id);
    }
}
