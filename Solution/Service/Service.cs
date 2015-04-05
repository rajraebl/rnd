using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.ServiceModel;
using System.Runtime.Serialization;
using Service.CreditReference;


[ServiceContract]
    public interface ICreditLimitRequest
    {
        [OperationContract(IsOneWay = true)]
        void SendCreditLimitRequest(string id);
    }

    public class CreditLimitRequestService : ICreditLimitRequest
    {
        public void SendCreditLimitRequest(string id)
        {
            double value;

            if (id == "1")
                value = 10;
            else if (id == "2")
                value = 20;
            else
                value = 0;

            CreditLimitResponseClient proxy = new CreditLimitResponseClient();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                proxy.SendCreditLimitResponse(value);
                scope.Complete();
            }
          
        }

       
    }

