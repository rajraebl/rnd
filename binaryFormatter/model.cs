using System;

namespace binaryFormatter
{
    [Serializable]
    public class IVehicle
    {
        public int Id;
        [NonSerialized]
        public string Name;
        public DateTime CreatedAt { get; set; } //properties are not serialised, will be via backing field
    }

    [Serializable]
    public class Car : IVehicle
    {
        private bool isNew;
    }

    [Serializable]
    public class Truck : IVehicle
    {
        private bool isOld;
    }
}
