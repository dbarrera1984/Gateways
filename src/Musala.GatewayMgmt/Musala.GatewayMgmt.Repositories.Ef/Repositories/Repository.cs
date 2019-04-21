using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Musala.Infrastructure;

namespace Musala.GatewayMgmt.Repositories.Ef.Repositories
{
    /// <summary>
    /// Serves as a generic base class for concrete repositories to support basic CRUD oprations on data in the system.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository works with. Must be a class inheriting MusalaEntity.</typeparam>
    public abstract class Repository<T, K> : IRepository<T, K>, IDisposable where T : MusalaEntity<K>
    {

        public abstract T FindById(K id, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IQueryable of the requested type T.</returns>
        public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = DataContextFactory.GetDataContext().Set<T>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items.OrderBy(o => o.Id);
        }

        /// <summary>
        /// Returns an IQueryable of items of type T.
        /// </summary>
        /// <param name="predicate">A predicate to limit the items being returned.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>An IEnumerable of the requested type T.</returns>
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = DataContextFactory.GetDataContext().Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items.Where(predicate).OrderBy(o => o.Id);
        }

        /// <summary>
        /// Adds an entity to the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be added.</param>
        public virtual void Add(T entity)
        {
            DataContextFactory.GetDataContext().Set<T>().Add(entity);
        }

        /// <summary>
        /// Update an entity to the underlying DbContext. This method updates all entity's properties
        /// </summary>
        /// <param name="entity">The entity that should be updated.</param>
        public virtual void Update(T entity)
        {
            var state = DataContextFactory.GetDataContext().Entry(entity).State;
            DataContextFactory.GetDataContext().Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext.
        /// </summary>
        /// <param name="entity">The entity that should be removed.</param>
        public virtual void Remove(T entity)
        {
            DataContextFactory.GetDataContext().Set<T>().Remove(entity);
        }

        /// <summary>
        /// Removes an entity from the underlying DbContext. Calls <see cref="FindById" /> to resolve the item.
        /// </summary>
        /// <param name="id">The ID of the entity that should be removed.</param>
        public virtual void Remove(K id)
        {
            Remove(FindById(id));
        }

        /// <summary>
        /// Disposes the underlying data context.
        /// </summary>
        public void Dispose()
        {
            if (DataContextFactory.GetDataContext() != null)
            {
                DataContextFactory.GetDataContext().Dispose();
            }
        }

        public PagedResult<T> PagedResult(IQueryable<T> query, int page, int pageSize)
        {
            var results = from o in query
                orderby o.Id
                select o;

            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize);

            return result;
        }
    }
}
