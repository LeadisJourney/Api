using System;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;

namespace LeadisTeam.LeadisJourney.Services
{
    public class AccountService : IAccountService {
        private readonly IAccountRepository _accountRepository;
	    private readonly IUserRepository _userRepository;

	    public AccountService(IAccountRepository accountRepository,
			IUserRepository userRepository) {
		    _accountRepository = accountRepository;
		    _userRepository = userRepository;
	    }

	    public void Create(string pseudo, string email, string name, string firstName, string password) {
            var account = new Account {
                Email = email,
                Password = password,
                IsOwner = false,
                Pseudo = pseudo,
                User = new User {
                    FirstName = firstName,
                    Name = name
                }
            };
            account.User.Account = account;
            _accountRepository.Save(account);
			_userRepository.Save(account.User);
        }

        public void Update(int id, string email, string firstName, string name, string password) {
            var account = _accountRepository.FindBy(id);
            if (account == null) {
                throw new ArgumentException(nameof(id));
            }
            account.Email = email;
            account.Password = password;
            account.User.Name = name;
            account.User.FirstName = firstName;
            _accountRepository.Save(account);
            _userRepository.Save(account.User);
        }

        public Account Get(int id) {
            var account = _accountRepository.FindBy(id);
            return account;
        }
    }
}
