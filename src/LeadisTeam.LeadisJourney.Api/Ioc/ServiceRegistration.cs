using Autofac;
using LeadisTeam.LeadisJourney.Services;
using LeadisTeam.LeadisJourney.Services.Contracts;

namespace LeadisTeam.LeadisJourney.Api.Ioc {
	public class ServiceRegistration : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterType<AccountService>()
				.As<IAccountService>();
		}
	}
}