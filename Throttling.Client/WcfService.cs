using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Throttling.Client
{//
    class WcfService : IWcfService
    {
        private Guid sessionGuid = Guid.NewGuid();
        public Guid Ping()
        {
            throw new NotImplementedException();
        }
    }

    [ServiceContract]
    public interface IWcfService
    {
        [OperationContract]
        Guid Ping();
    }
}
