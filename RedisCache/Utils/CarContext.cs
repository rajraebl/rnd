using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RedisCache.Models;

namespace RedisCache.Utils
{
    public class CarContext : DbContext
    {
        public CarContext() : base("CarContext")
        {
            Database.SetInitializer<CarContext>(new CarDbInitializer());
        }
       public DbSet<Car> CarSet { get; set; }
    }
}