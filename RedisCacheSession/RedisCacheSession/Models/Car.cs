using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedisCacheSession.Models
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
    }
}