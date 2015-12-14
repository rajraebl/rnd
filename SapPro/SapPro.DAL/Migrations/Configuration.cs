using System.Collections.Generic;
using SapPro.Entity;

namespace SapPro.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SapPro.DAL.SapProContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SapPro.DAL.SapProContext context)
        {
            var Products = new List<Product>()
            {
                new Product { Name = "Product 1", Category = "Category 1" },
                new Product { Name = "Product 2", Category = "Category 2" },
                new Product { Name = "Product 3", Category = "Category 3" },
                new Product { Name = "Product 11", Category = "Category 1" },
                new Product { Name = "Product 12", Category = "Category 2" },
                new Product { Name = "Product 13", Category = "Category 3" },
                new Product { Name = "Product 21", Category = "Category 1" },
                new Product { Name = "Product 22", Category = "Category 2" },
                new Product { Name = "Product 23", Category = "Category 3" }
            };

           Products.ForEach(item=> context.tblProduct.AddOrUpdate(p=>p.Name,item));
           context.SaveChanges();
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
        }
    }
}
