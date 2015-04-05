using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbReceiver
{
    using System.Linq.Expressions;
    using System.Threading;
    using Microsoft.ServiceBus.Messaging;

    class Program
    {
        private static string connStr = "Endpoint=sb://rajsbnmsp.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=8q/vO/Hsj2yVCDCTifq5VjOa/keujf29QEnyAzuHkqY=";
        static void Main(string[] args)
        {
            MessagingFactory mf = MessagingFactory.CreateFromConnectionString(connStr);
            MessageReceiver mr = mf.CreateMessageReceiver("rajsbqueue");
            while (true)
            {   
                Console.Write("Receiving Message.....");

                //As a message is retrieved from the queue it is pulled from the queue in one of two modes: either with RecieveAndDelete or PeekLock.
                //By default, a message is retrieved using the PeekLock mode of retrieval.
                        using (BrokeredMessage bm = mr.Receive()) //‘parameterless’ overload of Receive, which is a synchronous and blocking call. 
                        {   
                            try

                    {

                            var msgBody = bm.GetBody<string>();
                            Console.WriteLine("Message Received: {0}{1}", msgBody, "!!!");

                            //When a BrokeredMessage is pulled from the queue using the PeekLock, it is assigned a GUID as a LockToken.  This token is only valid during the Lock Duration.  If for some reason the code takes too long to process the message and the lock expires, when the code calls Complete it would receive a MessageLostLock exception since the token is no longer valid.  The message might have even already been handed off to another consumer to process by that time.  If necessary you can also call RenewLock on the message instance while processing, which will extend a still valid lock by the time set for the LockDuration on the queue.  In this way you can keep extending the time until you are finished processing if necessary.
                            //Thread.Sleep(30001);



                            //Once the code has finished processing, it calls Complete on the message.  This notifies the service bus that this message is completed and can be permanently removed from the queue.
                            bm.Complete();
                            //if something goes wrong during the processing and an exception is thrown, then the code calls Abandon on the message, notifying the service bus that the message could not be processed and it can be retrieved by another consumer
                                            }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    bm.Abandon();
                }

                        }
                Console.ReadLine();
            }
        }
    }
}
