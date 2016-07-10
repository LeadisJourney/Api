using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LeadisTeam.LeadisJourney.Repositories.Map;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Tool.hbm2ddl;

namespace LeadisTeam.LeadisJourney.Repositories.NHibernate {
    public static class ServiceCollectionExtensions {
        public static void AddNHibernate(this IServiceCollection serviceCollection,
            string type, string connectionString) {
            var configuration = Fluently.Configure()
                .Database(GetDatabaseConfiguration(type, connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountMap>());
#if DEBUG
            configuration = configuration.ExposeConfiguration(config => {
                var schemaExport = new SchemaExport(config);
                schemaExport.SetDelimiter(";");
                schemaExport.SetOutputFile("schema.sql").Execute(true, false, false);
            });
#endif

            var factory = configuration.BuildSessionFactory();

            serviceCollection.AddSingleton(factory);
            serviceCollection.AddScoped<IScopeFactory, ScopeFactory>();
        }

        private static IPersistenceConfigurer GetDatabaseConfiguration(string type, string connectionString) {
            if (type.Equals("mysql", StringComparison.CurrentCultureIgnoreCase)) {
                return MySQLConfiguration.Standard
                    .ConnectionString(connectionString);
            }
            if (type.Equals("mssql", StringComparison.CurrentCultureIgnoreCase)) {
                return MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString);
            }
            throw new ArgumentException($"Invalid database type {type}.");
        }
    }


}