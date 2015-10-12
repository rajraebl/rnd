using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using DateMePlease.Entities;
using DateMePlease.Models;

namespace DateMePlease.Data
{
  public class DateMePleaseContext : DbContext
  {
    public DateMePleaseContext(): base("dbDateMP")
    {
      this.Configuration.LazyLoadingEnabled = false;
      this.Configuration.ProxyCreationEnabled = false;
      Database.SetInitializer<DateMePleaseContext>(new DateMePleaseInitializer());
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<InterestType> InterestTypes { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<Demographics> Demographics { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Profile> Profile { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Member>()
        .HasOptional<Profile>(m => m.Profile)
        .WithRequired(m => m.Member)
        .Map(p => p.MapKey("MemberId"));
    }

    public override int SaveChanges()
    {
        Settledatetime2_datatype_to_datetime_datatype();
        return base.SaveChanges();
    }

    private void Settledatetime2_datatype_to_datetime_datatype()
    {
        foreach (var change in ChangeTracker.Entries<Demographics>())
        {
            var values = change.CurrentValues;
            foreach (var name in values.PropertyNames)
            {
                var value = values[name];
                if (value is DateTime)
                {
                    var date = (DateTime)value;
                    if (date < SqlDateTime.MinValue.Value)
                    {
                        values[name] = SqlDateTime.MinValue.Value;
                    }
                    else if (date > SqlDateTime.MaxValue.Value)
                    {
                        values[name] = SqlDateTime.MaxValue.Value;
                    }
                }
            }
        }
    }
  }
}