using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using RedisCache.Models;
using StackExchange.Redis;

namespace RedisCache.Utils
{
    public class ServiceProxy
    {
        public IEnumerable<Car> GetCars()
        {
            IEnumerable<Car> cars;
            IDatabase cache = CacheUtil.Connection.GetDatabase();
            if (cache.KeyExists("lstCars"))
            {
                cars = cache.Get<IEnumerable<Car>>("lstCars");
            }
            else
            {
                CarRepository repository = new CarRepository();
                cars = repository.GetCars();
                cache.Set("lstCars", cars);
            }
            return cars;
        }
    }
}