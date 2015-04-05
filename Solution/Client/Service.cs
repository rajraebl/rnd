using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

    [ServiceContract]
    public interface ICreditLimitResponse
    {
        [OperationContract(IsOneWay = true)]
        void SendCreditLimitResponse(double limit);
    }

    public class CreditLimitResponseService : ICreditLimitResponse
    {
        public void SendCreditLimitResponse(double limit)
        {
            System.Windows.Forms.MessageBox.Show(limit.ToString());
        }
    }

