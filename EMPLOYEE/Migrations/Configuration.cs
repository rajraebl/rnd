using EMPLOYEE.Models;

namespace EMPLOYEE.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EMPLOYEE.Models.EmpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMPLOYEE.Models.EmpContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.tblEmp.AddOrUpdate(x=>x.Id,
            new Employee() { Name = "Rajesh", Mobile = "9654", Email = "r@j.com" },
            new Employee() { Name = "Rajes", Mobile = "965", Email = "r@j.com" },
            new Employee() { Name = "Raje", Mobile = "954", Email = "r@j.com" },
            new Employee() { Name = "Raj", Mobile = "964", Email = "r@j.com" });

            
        }
    }
}
