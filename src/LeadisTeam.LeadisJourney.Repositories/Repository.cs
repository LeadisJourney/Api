using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LeadisTeam.LeadisJourney.Core.Entities;
using LeadisTeam.LeadisJourney.Core.Repositories;
using LeadisTeam.LeadisJourney.Repositories.Context;
using NHibernate;
using NHibernate.Linq;

namespace LeadisTeam.LeadisJourney.Repositories
{
    public class Repository<TEntity> : IPersistRepository<TEntity>, IReadOnlyRepository<TEntity> where TEntity : IEntity {
	    private readonly ISession _session;

	    public Repository(DbContext dbContext) {
		    if (dbContext == null) {
			    throw new ArgumentNullException(nameof(dbContext));
		    }
		    _session = dbContext.Session;
	    }

	    public void Save(TEntity entity) {
		    _session.SaveOrUpdate(entity);
	    }

	    public void Save(IEnumerable<TEntity> entities) {
		    foreach (var entity in entities) {
			    _session.SaveOrUpdate(entity);
		    }
	    }

	    public void Delete(TEntity entity) {
		    _session.Delete(entity);
	    }

	    public void Delete(IEnumerable<TEntity> entities) {
		    foreach (var entity in entities) {
			    _session.Delete(entity);
		    }
	    }

	    public IQueryable<TEntity> All() {
		    return _session.Query<TEntity>();
	    }

	    public IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression) {
		    return All().Where(expression).AsQueryable();
	    }

	    public TEntity FindBy(int id) {
		    return _session.Get<TEntity>(id);
	    }

	    public TEntity FindBy(Expression<Func<TEntity, bool>> expression) {
			return FilterBy(expression).SingleOrDefault();
		}
    }
}
