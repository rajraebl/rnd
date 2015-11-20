using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Web;

namespace EF_Inheritence.Models
{
    public class EFContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //making Nvarchar to varchar
            modelBuilder.Entity<Artist>().Property(t => t.Name).IsUnicode(false);

        }

        
    }
}