using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedisCache.Models;

namespace RedisCache.Utils
{
    public class CarRepository
    {
        public IEnumerable<Car> GetCars()
        {
            using (CarContext db = new CarContext())
            {
                return db.CarSet.ToList();
            }
        }
    }
}