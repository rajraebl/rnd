using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace RU.Models
{
    public class RUContext : DbContext
    {
        public DbSet<Course> CourseSet { get; set; }
        public DbSet<Student> StudentSet { get; set; }
        public DbSet<Enrollment> EnrollmentSet { get; set; }
        public DbSet<Department> DepartmentSet { get; set; }
        public DbSet<Instructor> InstructorSet { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignmentSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {//If you didn't do this, the generated tables would be named Students, Courses, and Enrollments. Instead, the table names will be Student, Course, and Enrollment
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Code First can configure the many-to-many relationship for you without this code, but if you don't call it, 
            //you will get default names such as InstructorInstructorID for the InstructorID column.
            modelBuilder.Entity<Course>().HasMany(c=>c.Instructors).WithMany(i=>i.Corses)
                .Map(t=>t.MapLeftKey("CourseID").MapRightKey("InstructorId")
                .ToTable("CourseInstructor"));

            /*The following code provides an example of how you could have used fluent API instead of attributes to specify the relationship between the Instructor and OfficeAssignment entities: 
            modelBuilder.Entity<Instructor>()
    .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);
             * */
        }
    }
}