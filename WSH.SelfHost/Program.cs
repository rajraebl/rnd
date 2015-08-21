using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WSH.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string HttpAddr = "http://localhost:56002/CalService";

           var sh = new ServiceHost(typeof(WSH.WCFService.CalcService), new Uri(HttpAddr));

            sh.AddServiceEndpoint(typeof(WSH.WCFService.ICalcService), new BasicHttpBinding(), HttpAddr);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(smb);
            sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");


            sh.Open();
            Console.WriteLine("Running.............");
            Console.Read();
        }
    }
}
