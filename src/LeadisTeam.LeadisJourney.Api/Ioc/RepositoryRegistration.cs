using Autofac;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories;

namespace LeadisTeam.LeadisJourney.Api.Ioc {
	public class RepositoryRegistration : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterType<AccountRepository>()
				.As<IAccountRepository>();
			builder.RegisterType<UserRepository>()
				.As<IUserRepository>();
            builder.RegisterType<GroupRepository>()
                .As<IGroupRepository>();
            builder.RegisterType<TutorialRepository>()
                .As<ITutorialRepository>();
		    builder.RegisterType<ExerciceRepository>()
		        .As<IExerciceRepository>();
		    builder.RegisterType<SourceRepository>()
		        .As<ISourceRepository>();
		}
	}
}