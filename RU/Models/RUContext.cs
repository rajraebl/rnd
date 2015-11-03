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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {//If you didn't do this, the generated tables would be named Students, Courses, and Enrollments. Instead, the table names will be Student, Course, and Enrollment
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); 
        }
    }
}