using LeadisTeam.LeadisJourney.Repositories.Map;
using NHibernate.Tool.hbm2ddl;

namespace LeadisTeam.LeadisJourney.Repositories.Context {
	public class LeadisJourneyContext : DbContext {
		static LeadisJourneyContext() {
			Configuration(DatabaseType.MySql, "localhost", 3306, "LeadisDB", "root", "specialitycoffee");
			MappingsConfiguration(c =>
			c.FluentMappings.AddFromAssemblyOf<AccountMap>().AddFromAssemblyOf<UserMap>().AddFromAssemblyOf<TutorialMap>()
			.AddFromAssemblyOf<ExerciceSourceMap>().AddFromAssemblyOf<ExerciceMap>().AddFromAssemblyOf<GroupMap>()
			.AddFromAssemblyOf<UserExperienceMap>().AddFromAssemblyOf<TutorialSourceMap>().AddFromAssemblyOf<HelpSourceMap>()).ExposeConfiguration(
				config => {
				    var schemaExport = new SchemaExport(config);
				    schemaExport.SetDelimiter(";");
				    schemaExport.SetOutputFile("schema.sql").Execute(true, false, false);
				}).BuildConfiguration();
			BuildSessionFactory();
		}
	}
}