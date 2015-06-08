using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
namespace binaryFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream ms = serialize();
            Console.WriteLine(new StreamReader(ms).ReadToEnd());
            ms.Position = 0;
            var ll = deserialize(ms);

        }

        public static Stream serialize()
        {
            Stream ms = new MemoryStream();
            var c = new Car() { Id = 3, Name = "Duster", CreatedAt = DateTime.Now };
            var t = new Truck() { Id = 21, Name = "Tuster", CreatedAt = DateTime.Now };

            //var bf = new BinaryFormatter();
            var bf = new SoapFormatter();
            bf.Serialize(ms,c);
            bf.Serialize(ms,t);
            ms.Position = 0;
            return ms;
        }

        public static IList<IVehicle> deserialize(Stream s)
        {
            IList<IVehicle> lst = new List<IVehicle>();
            
            //BinaryFormatter bf = new BinaryFormatter();
            var bf = new SoapFormatter();

            var c = (Car) bf.Deserialize(s);
            var t = (Truck)bf.Deserialize(s);
            lst.Add(c);
            lst.Add(t);
            return lst;
        }
    }

   
}
