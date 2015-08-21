using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace cf.client
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            //below code without endPoint name is also valid till u have single endpoint defined in web.config for that serviceContract
            //var cf = new ChannelFactory<cf.service.IService>("");

            var cf = new ChannelFactory<cf.service.IService>("dummyInvalidEndpoint"); //u can point to some invalid endpoint if need be 
            //but before making call u have to set the correct address as done in below line
            //here "dummyInvalidEndpoint" is just a dummy endpoint pointing to invalid service adress.

            cf.Endpoint.Address = new EndpointAddress("http://localhost:8733/myAddresses/cf.service/Service1");

            var sProxy = cf.CreateChannel();
            Console.WriteLine("calling the service: {0}", sProxy.Hello());
            foreach (var s in "rajesh sahu")
            {
                Thread.Sleep(500);
                Console.WriteLine("calling the method getdata: {0}", sProxy.GetData(new Random().Next(99)));
            }
            Console.WriteLine("calling Done !!!");

            Console.Read();
        }
    }
}
