using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using cf.service;

namespace cf.host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Service));
            host.Open();
            detail(host);
            Console.Read();
            host.Close();
        }

        private static void detail(ServiceHost sh)
        {
            Console.WriteLine("Address: {0}",sh.Description.Endpoints[0].Address);

            Console.WriteLine("Binding: {0}", sh.Description.Endpoints[0].Binding);
            Console.WriteLine("Contract: {0}", sh.Description.Endpoints[0].Contract);
            Console.WriteLine("State: {0}", sh.State.ToString());
        }
    }
}
