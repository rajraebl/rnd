using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace SubClientEven
{
    class Program
    {
        private static string connStr = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
        static readonly string TopicName = ConfigurationManager.AppSettings["TopicName"];
        static readonly string SubscriptionName = ConfigurationManager.AppSettings["SubscriptionName"];
        static void Main(string[] args)
        {
            initSub();
            startSub();
        }

        private static void startSub()
        {
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(connStr, TopicName, SubscriptionName);

            Console.WriteLine("Waiting for message to come");


            subscriptionClient.OnMessage((message) =>
            {
                try
                {
                    Console.WriteLine("Message Received!!!!!Message Number: " + message.Properties["MessageNumber"]);
                    Console.WriteLine("MessageID: " + message.MessageId + "///////Body: " + message.GetBody<string>());

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception)
                {
                    Console.WriteLine("Message Receiving Failed..........!");
                    message.Abandon();
                }
                Console.WriteLine("");
            });

            Console.Read();

        }

        private static void initSub()
        {
            NamespaceManager nm = NamespaceManager.CreateFromConnectionString(connStr);
            if (!nm.SubscriptionExists(TopicName, SubscriptionName))
                {
                    SqlFilter oddFilter = new SqlFilter("MessageNumber % 2 != 0");
                    nm.CreateSubscription(TopicName, SubscriptionName,oddFilter);

                }

        }
    }
}
