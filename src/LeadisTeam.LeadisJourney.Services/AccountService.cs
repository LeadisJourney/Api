﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Services.Contracts;
using LeadisTeam.LeadisJourney.Services.Exceptions;

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

        public string Encrypt(string elem) {

            HashAlgorithm hash = SHA256.Create();
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(elem);
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            elem = Convert.ToBase64String(hashBytes);
            return elem;
        }

	    public void Create(string pseudo, string email, string name, string firstName, string password) {
            if (_accountRepository.All().Any(a => a.Email.Equals(email)))
                throw new ExistingEmailException();
            else if (_accountRepository.All().Any(b => b.Pseudo.Equals(pseudo)))
	            throw new ExistingPseudoException();
     
            var account = new Account {
                Email = email,
                Password = Encrypt(password),
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
            if (account == null)
            {
                throw new BadIdException();
            }
            account.Email = email;
            account.Password = Encrypt(password);
            account.User.Name = name;
            account.User.FirstName = firstName;
            _accountRepository.Save(account);
            _userRepository.Save(account.User);
        }

        public Account Get(int id) {
            var account = _accountRepository.FindBy(id);
            return account;
        }

        public void Desactivate(int id) {
            var account = _accountRepository.FindBy(id);
            account.EntityState = EntityState.Desactivated;
            _accountRepository.Save(account);
        }

        public Account SignIn(string email, string password)
        {
            var pwd = Encrypt(password);
            return _accountRepository.All().FirstOrDefault(s => s.Email.Equals(email) && s.Password.Equals(pwd));
        }
    }
}
