using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntApp.DAL.Custom
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal EntAppEntities dbContext;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(EntAppEntities _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<TEntity>();

        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> list = dbSet;
            return dbSet.ToList();
        }


        public virtual TEntity GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Insert(TEntity obj)
        {
            dbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            dbSet.Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(int Id)
        {
            TEntity obj = GetById(Id);
            Delete(obj);
        }

        public void Delete(TEntity obj)
        {
            if(dbContext.Entry(obj).State == EntityState.Detached)
            {
                dbSet.Attach(obj);
            }
            dbSet.Remove(obj);
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// </summary>
        public virtual IQueryable<TEntity> GetQueryableWhere(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).AsQueryable();
        }

        public virtual TEntity GetWhere(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) != null;
        }

    }
}
