using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
namespace sbsender
{
    using System.Threading;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
            MessagingFactory mf = MessagingFactory.CreateFromConnectionString(connStr);
            
            // The MessageSender is an abstraction and we are using it in place of the QueueClient. Unless there is some functionality you absolutely must have from QueueClient, I highly recommend that you use the MessageSender abstraction.
            MessageSender ms = mf.CreateMessageSender("rajsbqueue"); //The name of the queue is passed in as a parameter to the CreateMessageSender method.  
            BrokeredMessage bm = null;
            while (true)
            {
                Console.Write("Message Sending....");

                //The maximum size of message you can send is 256KB, with a maximum of 64KB for the header, including any metadata
                bm = new BrokeredMessage("My Message Body" + DateTime.Now.ToString());

                Thread.Sleep(500);
                ms.Send(bm);
                
                Console.WriteLine("Message Sent!!!");
                Console.ReadLine();

            }
        }
    }
}
