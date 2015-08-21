using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        int Add(int a, int b);
        [OperationContract]
        int Substract(int a, int b);
    }

    public class CalcService : ICalcService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Substract(int a, int b)
        {
            return a - b;
        }
    }
}
