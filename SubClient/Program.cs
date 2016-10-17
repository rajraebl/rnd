using System;
using System.Configuration;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;


namespace SubClient
{
    class Program
    {
        private static string connStr = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
        static readonly string TopicName = ConfigurationManager.AppSettings["TopicName"];
        static readonly string SubscriptionName = ConfigurationManager.AppSettings["SubscriptionName"];
        static void Main(string[] args)
        {
            initSub();
            //startSub();
            GetInvoiceDetail();
        }

        private static void startSub()
        {
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(connStr, TopicName, SubscriptionName);

            Console.WriteLine("Waiting for message to come");


            subscriptionClient.OnMessage((message) =>
            {
                try
                {
                    Console.WriteLine("Message Received!!!!!Message Number: " + message.Properties["MessageNumber"] + ":DeliveryCount:" + message.DeliveryCount);
                    Console.WriteLine("MessageID: " + message.MessageId + "///////Body: " + message.GetBody<string>());

                    // Remove message from subscription.
                    //message.Complete();
                }
                catch (Exception ex)
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
                nm.CreateSubscription(TopicName, SubscriptionName);
        }

        public static void GetInvoiceDetail()
        {


            BrokeredMessage message = null;

            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(connStr, TopicName, SubscriptionName);

            while (true)
            {
                try
                {
                    message = subscriptionClient.Receive(TimeSpan.FromMinutes(1));

                    if (message != null)
                    {
                        var json = message.GetBody<string>();
                        Console.WriteLine("Message Received!!!!!Message Number: " + message.Properties["MessageNumber"] + ":DeliveryCount:" + message.DeliveryCount);

                        var rows = 0;
                        if (rows > 0)
                        {
                            message.Complete();
                        }
                        else
                        {
                            Console.WriteLine();
                            //message.Abandon(); //If u peek a message and dont mark it either complete or abandone, then when the lock expires the message reappears in queue. And each time you peak a message, its property message.DeliveryCount is increased by one.
                            //This peak and lock expire and reappearing in queue goes on untill max deliverycount is reached and then it is deadlettered.
                        }
                    }
                    
                }
                catch (MessagingException ex)
                {
                    message.Abandon();

                        throw;
                    }

            }

        }
    }
}
