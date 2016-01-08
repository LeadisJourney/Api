using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;

namespace LeadisTeam.LeadisJourney.Services
{
    public class GroupService : IGroupService {
        private readonly IGroupRepository _groupRepository;
        private readonly IAccountRepository _accountRepository;

        public GroupService(IGroupRepository groupRepository,
            IAccountRepository accountRepository) {
            _groupRepository = groupRepository;
            _accountRepository = accountRepository;
        }

        public void Create(string name, int adminId) {
            var group = new Group() {
                Name = name
            };
            var account = _accountRepository.FindBy(adminId);
            group.Admins = new List<Account>();
            group.Admins.Add(account);
            _groupRepository.Save(group);
        }

        public void AddUser(List<int> accountsId, int id) {
            var group = _groupRepository.FindBy(id);
            foreach (var accountId in accountsId) {
                var account = _accountRepository.FindBy(accountId);
                account.Group.Add(group);
                group.Members.Add(account);
                _accountRepository.Save(account);
            }
            _groupRepository.Save(group);
        }

        public void DeleteUser(List<int> accountsId, int id) {
            var group = _groupRepository.FindBy(id);
            foreach (var accountId in accountsId) {
                var account = _accountRepository.FindBy(accountId);
                account.Group.Remove(group);
                group.Members.Remove(account);
                _accountRepository.Save(account);
            }
            _groupRepository.Save(group);
        }
    }
}
