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
    public abstract class RepositoryGuid<T> : Repository<T, Guid>, IRepository<T, Guid>, IDisposable where T : MusalaEntity<Guid>
    {
        /// <summary>
        /// Finds an item by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the item in the database.</param>
        /// <param name="includeProperties">An expression of additional properties to eager load. For example: x => x.SomeCollection, x => x.SomeOtherCollection.</param>
        /// <returns>The requested item when found, or null otherwise.</returns>
        public override T FindById(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id == id);
        }
    }
}
