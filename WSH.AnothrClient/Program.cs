using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSH.AnothrClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //u can manually generate the proxy using below command on vs command tool
            //svcutil http://localhost:8030/Service1.svc /out:CalcServiceProxy.cs /config:app.config  
            //this will genegrate 2 files one for servieproxyImplementation and another for config file.
                                                        
            CalcServiceClient c = new CalcServiceClient();

            Console.WriteLine("" + c.Add(-1,-3));

            Console.Read();
        }
    }
}
