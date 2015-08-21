using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    [ServiceContract]
    public interface IServiceContract<T>
    {
        [OperationContract(IsOneWay = true)]
        void GetData(int value);
    }
}
