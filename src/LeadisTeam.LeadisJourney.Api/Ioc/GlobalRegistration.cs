using Autofac;

namespace LeadisTeam.LeadisJourney.Api.Ioc {
	public class GlobalRegistration : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterModule<ServiceRegistration>();
			builder.RegisterModule<RepositoryRegistration>();
		}
	}
}