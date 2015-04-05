using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;

namespace ServiceBusEnviro
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(ServiceBusEnvironment.DefaultIdentityHostName);
            Console.WriteLine(ServiceBusEnvironment.CreateAccessControlUri("pola"));
            Console.WriteLine(ServiceBusEnvironment.SystemConnectivity.Mode);
            Console.WriteLine(ServiceBusEnvironment.CreateServiceUri("http", "pola", string.Empty, true));
            Console.WriteLine(ServiceBusEnvironment.CreateServiceUri("http", "pola", string.Empty, false));

            Console.ReadLine();
        }
    }
}
