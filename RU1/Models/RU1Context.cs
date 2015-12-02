using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    //Enable-Migrations -ContextTypeName RU1.Models.RU1Context

    public class RU1Context : DbContext
    {
        public DbSet<Course> tblCourse { get; set; }
        public DbSet<Student> tblStudent { get; set; }

        public DbSet<Enrollment> tblEnrollment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}