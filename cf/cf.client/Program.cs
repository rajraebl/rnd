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
            var cf = new ChannelFactory<cf.service.IService>("");
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
