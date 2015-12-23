using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RU1.Models;

/*
Use the DbSet.SqlQuery method for queries that return entity types. The returned objects must be of the type expected by the DbSet object, and they are automatically tracked by the database context unless you turn tracking off. (See the following section about the AsNoTracking method.)
Use the Database.SqlQuery method for queries that return types that aren't entities. The returned data isn't tracked by the database context, even if you use this method to retrieve entity types.
Use the Database.ExecuteSqlCommand for non-query commands.
 */

namespace RU1
{
    public class GenericRepository<T> where T: class
    {
        RU1Context context;
        DbSet<T> dbset;

        public GenericRepository(RU1Context context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

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

        public virtual T getById(int id)
        {
            return dbset.Find(id);
        }

        public virtual void add(T t)
        {
            dbset.Add(t);
        }

        public virtual void update(T t){
            context.Entry(t).State = System.Data.EntityState.Modified;
        }

        public virtual void delete(int id) {
            delete(dbset.Find(id));
        }

        public virtual void delete(T t) {
            dbset.Remove(t);
        }

        public virtual IEnumerable<T> GetWithRawSql(string query, params object[] parameters)
        {
            return dbset.SqlQuery(query, parameters);
        } 

    }
}