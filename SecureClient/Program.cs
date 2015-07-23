using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SecureClient.ServiceNmsp;
using IService1 = SecureService.IService1;

namespace SecureClient
{
    class Program
    {
        static void Main(string[] args)
        {//http://www.codeproject.com/Articles/318810/WCF-Service-Method-Level-Security-using-Message-Co
            //CALL FROM ADD WEB REFERENCE USING PROXY
            ServiceNmsp.Service1Client client = new ServiceNmsp.Service1Client();
            cc(client.GetData(56));

            //CALL FROM CAHNNEL FACTORY BY ADDING EXTRA ENDPOINT AT CLIENT
            SecureService.AccountCredential credential = new SecureService.AccountCredential();
            credential.CustId = "007";
            credential.SecretKey = "ola";

            ChannelFactory<SecureService.IService1> svc = new ChannelFactory<SecureService.IService1>("");

            IService1 serviceProxy = svc.CreateChannel();

            try
            {
                SecureService.AccountInfo info = serviceProxy.GetAccountInfo(credential);
                cc("balance in account is: " + info.Balance);

            }
            catch (Exception)
            {
                
                throw;
            }


            

            Console.Read();
        }

        private static void cc(object s)
        {

            Console.WriteLine(s);
        }
        private static void ccc(object s)
        {
            Console.WriteLine("-------" + s);
        }

    }
}
