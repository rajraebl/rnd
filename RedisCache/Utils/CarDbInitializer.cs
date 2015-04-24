using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using RedisCache.Models;

namespace RedisCache.Utils
{
    public class CarDbInitializer: DropCreateDatabaseIfModelChanges<CarContext>
    {
        protected override void Seed(CarContext context)
        {
            context.CarSet.Add(new Car() { CarModel = "ACURA" });
            context.CarSet.Add(new Car() { CarModel = "SEDAN 4 DR" });
            context.CarSet.Add(new Car() { CarModel = "STATION WAGON" });
            base.Seed(context);
        }
    }
}
