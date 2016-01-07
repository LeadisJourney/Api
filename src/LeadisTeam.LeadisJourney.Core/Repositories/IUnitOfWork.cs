using System;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
	public interface IUnitOfWork : IDisposable {
		void Rollback();
		void Commit();
	}
}