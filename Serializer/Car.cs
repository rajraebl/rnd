using System;


namespace Serializer
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
