using System;
using System.Configuration;
using StackExchange.Redis;

namespace RedisCache.Utils
{
    public class CacheUtil
    {
        private readonly static string RedisCacheName = ConfigurationManager.AppSettings["RedisCacheName"];
        private readonly static string RedisCacheKey = ConfigurationManager.AppSettings["RedisCacheKey"];

       
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(string.Format("{0},ssl=true,password={1}", RedisCacheName, RedisCacheKey));
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
      
        //public static ConnectionMultiplexer Connection { get; private set; }
        //static CacheUtil()
        //{
        //    Connection = ConnectionMultiplexer.Connect(string.Format("{0},ssl=true,password={1}", RedisCacheName, RedisCacheKey));  
        //}
    }
}