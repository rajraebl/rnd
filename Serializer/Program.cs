using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool i = true;
            while (i)
            {
                Console.WriteLine("Please input command");
                string cmd = Console.ReadLine();

                if (cmd == "e")
                {
                    Console.WriteLine("We are exiting");
                    i = false;
                    return;
                }
                
                else if (cmd == "d")
                {
                    deserialize();
                }
                else
                {
                    serialize();
                    Console.WriteLine("Serialization Done !!");
                } 
            }
        }

        static void serialize()
        {
            using (FileStream fs = new FileStream("car.xml", FileMode.Create))
            {
                Car c = new Car() {Id = 3, Name = "Duster", CreatedAt = DateTime.Now};

                DataContractSerializer dc = new DataContractSerializer(typeof(Car));
                
                dc.WriteObject(fs,c);

            }
        }
        static void deserialize()
        {
            using (FileStream fs = new FileStream("car.xml", FileMode.Open))
            {
                Car c; 

                DataContractSerializer dc = new DataContractSerializer(typeof(Car));

               c = dc.ReadObject(fs) as Car;

               Console.WriteLine("Deserialization Done !! Car Name is {0} and was manufactured at {1}",c.Name,c.CreatedAt.ToString());

            }
        }


    }
}
