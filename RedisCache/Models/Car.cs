using System;

namespace RedisCache.Models
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; }
        public string CarModel { get; set; }
    }
}
