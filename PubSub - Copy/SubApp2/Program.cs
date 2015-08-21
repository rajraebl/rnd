using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace SubApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
            var sc = SubscriptionClient.CreateFromConnectionString(connStr, "Topic1", "Sub2");
            sc.OnMessage((m) =>
            {
                cc("############### MESSAGE RECEIVED AT SUB-2 ##############");
                cc("MessageBody :" + m.GetBody<string>());
                Console.WriteLine("MessageID: " + m.MessageId);
                Console.WriteLine("Message Properties: " + m.Properties["insId"]);
                Console.WriteLine("insType: " + m.Properties["insType"]);
                m.Complete();

            });

            Console.Read();
        }

        private static void cc(object s)
        {
            Console.WriteLine(s);
        }

    }
}
