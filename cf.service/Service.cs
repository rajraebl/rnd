using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace cf.service
{
    using System.Security.Cryptography.X509Certificates;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Hello();

        [OperationContract]
        string GetData(int value);
    }
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string Hello()
        {
            return "Helo World";
        }
    }
}
