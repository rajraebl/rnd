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
       public DbSet<Car> CarSet { get; set; }
    }
}