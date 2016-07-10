using NHibernate;

namespace LeadisTeam.LeadisJourney.Repositories.NHibernate {
    public interface IScopeFactory {
        ISession Create();
        void BeginTransaction();
        void Commit();
    }
}