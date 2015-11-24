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
    public class GenericRepository<T> where T : class
    {   //FOR GENERIC REPOSITORY WE NEED DBCONTEXT AND DBSET
        internal RUContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(RUContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
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

        /*
        Use the DbSet.SqlQuery method for queries that return entity types. The returned objects must be of the type expected by the DbSet object, and they are automatically tracked by the database context unless you turn tracking off. (See the following section about the AsNoTracking method.)
        Use the Database.SqlQuery method for queries that return types that aren't entities. The returned data isn't tracked by the database context, even if you use this method to retrieve entity types.
        Use the Database.ExecuteSqlCommand for non-query commands.
         */
        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);
        }

    }
}