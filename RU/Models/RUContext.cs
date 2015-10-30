using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RU.Models
{
    public class RUContext : DbContext
    {
        public DbSet<Student> StudentSet { get; set; }
        public DbSet<Course> CourseSet { get; set; }
        public DbSet<Enrollment> EnrollmentSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}