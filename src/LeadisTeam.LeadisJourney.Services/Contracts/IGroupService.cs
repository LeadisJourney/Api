using System.Collections.Generic;

namespace LeadisTeam.LeadisJourney.Services.Contracts
{
    public interface IGroupService {
        void Create(string name, int adminId);
        void AddUser(List<int> accountsId, int id);
        void DeleteUser(List<int> accountsId, int id);
    }
}
