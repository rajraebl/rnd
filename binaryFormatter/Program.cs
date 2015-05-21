using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace binaryFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static Stream serialize()
        {
            MemoryStream ms = new MemoryStream();
            Car c = new Car() { Id = 3, Name = "Duster", CreatedAt = DateTime.Now };
            
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms,c);
            return ms;
        }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
