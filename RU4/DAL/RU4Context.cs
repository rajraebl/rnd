using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RU4.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace RU4.DAL
{
    public class RU4Context:DbContext
    {
        public DbSet<Student> tblStudent { get; set; }
        public DbSet<Course> tblCourse { get; set; }
        public DbSet<Enrollment> tblEnrollment { get; set; }
        public DbSet<Instructor> tblInstructor { get; set; }
        public DbSet<Department> tblDepartment { get; set; }
        public DbSet<OfficeAssignment> tblOfficeAssignment { get; set; }
        



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Course>()
             .HasMany(c => c.Instructors).WithMany(i => i.Courses)
             .Map(t => t.MapLeftKey("CourseID")
                 .MapRightKey("InstructorID")
                 .ToTable("CourseInstructor"));
            /*
             An entity may be in one of the following states:
Added. The entity does not yet exist in the database. The SaveChanges method must issue an INSERT statement.
Unchanged. Nothing needs to be done with this entity by the SaveChanges method. When you read an entity from the database, the entity starts out with this status.
Modified. Some or all of the entity's property values have been modified. The SaveChanges method must issue an UPDATE statement.
Deleted. The entity has been marked for deletion. The SaveChanges method must issue a DELETE statement.
Detached. The entity isn't being tracked by the database context.
             * Some developers prefer to use the fluent API exclusively so that they can keep their entity classes "clean."
             */
        }
    }
}