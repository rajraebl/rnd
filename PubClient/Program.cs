using System;
using System.Configuration;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace PubClient
{
    class Program
    {
        static readonly string ConnStr = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
        static readonly string TopicName = ConfigurationManager.AppSettings["TopicName"];

        static void Main(string[] args)
        {
            
            InitPub();
            StartPub();
        }

        private static void StartPub()
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(ConnStr, TopicName);

            while (true)
            {
                Console.WriteLine("Please enter number of message to send:");
                var messageCount = Convert.ToInt16( Console.ReadLine());

                for (int i = 1; i <= messageCount; i++)
                {
                    var msg = new BrokeredMessage("Message:" + i + " sent at:" + DateTime.Now);
                    msg.Properties["MessageNumber"] = i;
                    topicClient.Send(msg);
                    Console.WriteLine("Message Sent:" + i);
                }

            }
        }

        

        public static void InitPub()
        {
            
            NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(ConnStr);

            if (!namespaceManager.TopicExists(TopicName))
                namespaceManager.CreateTopic(TopicName);
        }
    }
}
