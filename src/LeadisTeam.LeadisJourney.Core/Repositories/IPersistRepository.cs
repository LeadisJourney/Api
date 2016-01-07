using System.Collections.Generic;
using System.Linq;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories
{
    public interface IPersistRepository<TEntity> where TEntity : IEntity {
        void Save(TEntity entity);
	    void Save(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
	    void Delete(IEnumerable<TEntity> entities);
    }
}