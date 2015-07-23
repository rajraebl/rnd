using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SecureService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }



        public AccountInfo GetAccountInfo(AccountCredential credential)
        {
            if (credential.SecretKey == null)
                throw new FaultException("SecretKey is null");
            if(credential.SecretKey != "ola")
                throw new FaultException("UnAuthorised Access");

            return new AccountInfo()
            {
                Balance = 9870,
                Bank = "State Bank of India", Name = "Rajesh"
            };
        }
    }
}
