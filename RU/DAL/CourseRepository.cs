using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RU.Models;

namespace RU.DAL
{
    public class CourseRepository : GenericRepository<Course>
    {
        public CourseRepository(RUContext context) : base(context)
        {
        }

        public int UpdateCourseCredits(byte? multiplier)
        {   //Use the DbSet.SqlQuery method for queries that return entity types. The returned objects must be of the type expected by the DbSet object, and they are automatically tracked by the database context unless you turn tracking off. (See the following section about the AsNoTracking method.)
            //Use the Database.SqlQuery method for queries that return types that aren't entities. The returned data isn't tracked by the database context, even if you use this method to retrieve entity types.
            //Use the Database.ExecuteSqlCommand for non-query commands.
            return context.Database.ExecuteSqlCommand("update course set credits= credits*{0}", multiplier);
        }
    }
}