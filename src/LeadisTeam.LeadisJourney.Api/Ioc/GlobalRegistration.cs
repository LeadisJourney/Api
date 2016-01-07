using Autofac;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;

namespace LeadisTeam.LeadisJourney.Api.Ioc {
	public class GlobalRegistration : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterType<LeadisJourneyContext>()
				.As<IUnitOfWork>()
				.As<DbContext>()
				.InstancePerLifetimeScope();
			builder.RegisterModule<ServiceRegistration>();
			builder.RegisterModule<RepositoryRegistration>();
		}
	}
}