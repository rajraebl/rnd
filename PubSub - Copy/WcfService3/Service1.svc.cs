using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.ServiceBus.Messaging;

namespace WcfService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service3 : IService3
    {
        public void GetData(int value)
        {
            postMessageToTopic(value);

        }
        private void postMessageToTopic(int value)
        {
            string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
            var tc = TopicClient.CreateFromConnectionString(connStr, "Topic1");
            var bm = new BrokeredMessage("ola");
            bm.Properties["insId"] = value;
            bm.Properties["insType"] = "f3";
            tc.Send(bm);
        }


    }
}
