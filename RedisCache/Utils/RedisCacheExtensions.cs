using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StackExchange.Redis;


namespace RedisCache.Utils
{
    public static class RedisCacheExtensions
    {
        public static T Get<T>(this IDatabase cache, string key)
        {
            return Deserialize<T>(cache.StringGet(key));
        }

        public static object Get(this IDatabase cache, string key)
        {
            return Deserialize<object>(cache.StringGet(key));
        }

        public static void Set(this IDatabase cache, string key, object value)
        {
            //you can configure to get this expiry from your app settings
            cache.StringSet(key, Serialize(value), TimeSpan.FromMinutes(2));
        }

        static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}