using Autofac;
using LeadisTeam.LeadisJourney.Api.Security;
using LeadisTeam.LeadisJourney.Services;
using LeadisTeam.LeadisJourney.Services.Contracts;

namespace LeadisTeam.LeadisJourney.Api.Ioc {
	public class ServiceRegistration : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterType<AccountService>()
				.As<IAccountService>();
		    builder.RegisterType<Authenticator>()
		        .As<Authenticator>();
            builder.RegisterType<GroupService>()
                .As<IGroupService>();
        }
	}
}