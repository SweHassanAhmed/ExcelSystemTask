using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        // Marks an entity as new
        T Add(T entity);

        // Marks an entity as modified
        void Update(int id, T entity);

        // Marks an entity to be removed
        void Delete(int id, T entity);

        // Get an entity by int id
        T GetById(int id);

        // Gets all entities of type T
        IEnumerable<T> GetAll();
    }
}
