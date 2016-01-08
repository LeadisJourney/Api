using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface IAccountService {
        void Create(string pseudo, string email, string name, string firstName, string password);
        void Update(int id, string email, string firstName, string name, string password);
        Account Get(int id);
        void Desactivate(int id);
    }
}
