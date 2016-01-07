using System;
using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LeadisTeam.LeadisJourney.Core.Repositories;
using NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories.Context {
	public class DbContext : IUnitOfWork {
		public enum DatabaseType {
			PostGreSql,
			MsSql,
			MySql
		}
		private static FluentConfiguration _fluentConfiguration;
		private static ISessionFactory _sessionFactory;
		internal ISession Session { get; }
		private readonly ITransaction _transaction;

		public DbContext() {
			Session = OpenSession();
			Session.FlushMode = FlushMode.Auto;
			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		#region Static Methods
		public static ISession OpenSession() {
			if (_sessionFactory == null) {
				_sessionFactory = _fluentConfiguration.BuildSessionFactory();
			}
			return _sessionFactory.OpenSession();
		}
		protected static void Configuration(DatabaseType databaseType,string host,
			int port, string database, string username, string password) {
			switch (databaseType) {
				case DatabaseType.PostGreSql:
					_fluentConfiguration = Fluently.Configure()
						.Database(PostgreSQLConfiguration.Standard
						.ConnectionString(c => c.Host(host)
						.Port(port)
						.Database(database)
						.Username(username)
						.Password(password)));
					break;
				case DatabaseType.MsSql:
					_fluentConfiguration = Fluently.Configure()
						.Database(MsSqlConfiguration.MsSql2012
						.ConnectionString(c => c.Server(host)
						.Database(database)
						.TrustedConnection()));
					break;
				case DatabaseType.MySql:
					_fluentConfiguration = Fluently.Configure()
						.Database(MySQLConfiguration.Standard
						.ConnectionString(c => c.Server(host)
						.Database(database)
						.Username(username)
						.Password(password)));
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(databaseType), databaseType, null);
			}
		}

		protected static FluentConfiguration MappingsConfiguration(Action<MappingConfiguration> mappings) {
			return _fluentConfiguration.Mappings(mappings);
		}

		protected static void BuildSessionFactory() {
			_sessionFactory = _fluentConfiguration.BuildSessionFactory();
		}
		#endregion

		#region IUnitOfWork
		public void Rollback() {
			if (_transaction.IsActive) {
				_transaction.Rollback();
			}
		}

		public void Commit() {
			if (!_transaction.IsActive) {
				throw new InvalidOperationException("Oops! they don't have any active transaction");
			}
			try {
				_transaction.Commit();
			}
			catch {
				_transaction.Rollback();
				throw;
			}
			finally {
				Session.Close();
			}
		}
		#endregion

		#region IDisposable
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				if (Session.IsOpen) {
					Session.Close();
				}
			}
		}
		#endregion
	}
}
