using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using Moq;
using Xunit;

namespace LeadisTeam.LeadisJourney.Services.Tests {
	public class AccountServiceTests {
		private readonly Mock<IAccountRepository> _accountRepositoryMock;
		private readonly Mock<IUserRepository> _userRepositoryMock;

		private readonly AccountService _accountService;

		private IAccountRepository AccountRepository => _accountRepositoryMock.Object;
		private IUserRepository UserRepository => _userRepositoryMock.Object;

		public AccountServiceTests() {
			_accountRepositoryMock = new Mock<IAccountRepository>();
			_userRepositoryMock = new Mock<IUserRepository>();
			_accountService = new AccountService(AccountRepository, UserRepository);
		}

		[Fact]
		[Trait("Category", "Unit")]
		public void GivenAccountService_WhenCreate_ThenShouldRegisterAnAccount() {
			_accountService.Create("Peter", "Peter@Griffin.ca", "Griffin", "Peter", "Megatron");

			_accountRepositoryMock.Verify(f => f.Save(It.IsAny<Account>()));
		}

		[Fact]
		[Trait("Category", "Unit")]
		public void GivenAccountService_WhenCreate_ThenShouldRegisterAnUser() {
			_accountService.Create("Peter", "Peter@Griffin.ca", "Griffin", "Peter", "Megatron");

			_userRepositoryMock.Verify(f => f.Save(It.IsAny<User>()));
		}
	}
}
