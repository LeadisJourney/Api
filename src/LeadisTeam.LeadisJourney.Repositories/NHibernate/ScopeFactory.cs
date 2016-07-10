using NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories.NHibernate {
    public class ScopeFactory : IScopeFactory {
        private readonly ISessionFactory _sessionFactory;
        private ISession _session;
        private ITransaction _transaction;

        private ISession Session => _session ?? (_session = _sessionFactory.OpenSession());

        public ScopeFactory(ISessionFactory sessionFactory) {
            _sessionFactory = sessionFactory;
        }

        public ISession Create() {
            return Session;
        }

        public void BeginTransaction() {
            _transaction = Session.BeginTransaction();
        }

        public void Commit() {
            if (_transaction == null) {
                throw new TransactionException("Transaction should be begin before try to commit.");
            }
            if (!_transaction.IsActive) {
                throw new TransactionException("Transaction is no longer active.");
            }
            try {
                _transaction.Commit();
            } catch {
                _transaction.Rollback();
            } finally {
                Session.Dispose();
            }
        }
    }
}