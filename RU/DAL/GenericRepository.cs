using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RU.Models;

namespace RU.DAL
{   //This generic repository will handle typical CRUD requirements. When a particular entity type has special requirements, such as more complex filtering or ordering, 
    //you can create a derived class that has additional methods for that type.
    public class GenericRepository<T> where T: class
    {   //FOR GENERIC REPOSITORY WE NEED DBCONTEXT AND DBSET
        internal RUContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(RUContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //applies the eager-loading expressions after parsing the comma-delimited list:
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(T t)
        {
            dbSet.Add(t);
        }

        public virtual void Delete(object id)
        {
            T t = dbSet.Find(id);
            Delete(t);
        }

        public virtual void Delete(T t)
        {
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }

            dbSet.Remove(t);
        }

        public virtual void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }

    }
}