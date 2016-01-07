using System;
using System.Linq;
using System.Linq.Expressions;
using LeadisTeam.LeadisJourney.Core.Entities;

namespace LeadisTeam.LeadisJourney.Core.Repositories {
	public interface IReadOnlyRepository<TEntity> where TEntity : IEntity {
		IQueryable<TEntity> All();
		IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
		TEntity FindBy(int id);
		TEntity FindBy(Expression<Func<TEntity, bool>> expression);
	}
}