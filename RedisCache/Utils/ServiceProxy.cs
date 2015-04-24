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
        //Implementing a proxy kind of implementation used in comparenow.
        public IEnumerable<Car> GetCars()
        {
            IEnumerable<Car> cars;

            //If we want to use multiple databases (named cache in case of Managed Cache) then we can pass parameter here.
            IDatabase cache = CacheUtil.Connection.GetDatabase();
            if (cache.KeyExists("Cars"))
            {
                cars = cache.Get<IEnumerable<Car>>("Cars");
            }
            else
            {
                // cache aside implementation
                CarRepository repository = new CarRepository();
                cars = repository.GetCars();
                cache.Set("Cars", cars);
            }
            return cars;
        }
    }
}