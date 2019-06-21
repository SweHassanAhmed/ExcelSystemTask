using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Infrastructure
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        #region Properties

        private BaseEntity dataContext;
        private readonly DbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected BaseEntity DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }

        #endregion

        protected BaseRepository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation

        public virtual T Add(T entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;
            entity.IsActive = true;
            return dbSet.Add(entity).Entity;
        }

        public void Update(int id, T entity)
        {
            var local = dbSet.Find(id);
            if (local != null)
            {
                dataContext.Entry(local).State = EntityState.Detached;
            }

            entity.ModificationDate = DateTime.Now;
            //if (entity.IsActive)
            //    entity.IsActive = true;

            dbSet.Attach(entity);

            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id, T entity)
        {
            entity.IsActive = false;
            Update(id, entity);
        }

        public T GetById(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null)
            {
                if (entity.IsActive == true)
                {
                    return entity;
                }
            }
            return null;
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.Where(a => a.IsActive == true).ToList();
        }

        #endregion

    }
}
