using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RU2.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RU2.DAL
{
    public class RU2Context:DbContext
    {
        public DbSet<Student> tblStudent { get; set; }
        public DbSet<Course> tblCourse { get; set; }
        public DbSet<Enrollment> tblEnrollment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*
             An entity may be in one of the following states:
Added. The entity does not yet exist in the database. The SaveChanges method must issue an INSERT statement.
Unchanged. Nothing needs to be done with this entity by the SaveChanges method. When you read an entity from the database, the entity starts out with this status.
Modified. Some or all of the entity's property values have been modified. The SaveChanges method must issue an UPDATE statement.
Deleted. The entity has been marked for deletion. The SaveChanges method must issue a DELETE statement.
Detached. The entity isn't being tracked by the database context.
             */
        }
    }
}