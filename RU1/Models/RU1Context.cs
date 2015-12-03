using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using RU1.Migrations;

namespace RU1.Models
{
    //Enable-Migrations -ContextTypeName RU1.Models.RU1Context

    public class RU1Context : DbContext
    {
        public DbSet<Course> tblCourse { get; set; }
        public DbSet<Student> tblStudent { get; set; }

        public DbSet<Enrollment> tblEnrollment { get; set; }

        public DbSet<Instructor> tblInstructor { get; set; }
        public DbSet<Department> tblDepartment { get; set; }

        public DbSet<OfficeAssignment> tblOfficeAssignment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c=>c.Instructors).WithMany(i=>i.Courses)
                .Map(t=>t.MapLeftKey("CourseId")
                .MapRightKey("InstructorId").ToTable("CourseInstructor")
                );
        }
    }
}