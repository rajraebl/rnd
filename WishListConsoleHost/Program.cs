using System;
using System.ServiceModel;
using System.Messaging;
using WishListService;




namespace WishListConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host  =new ServiceHost(typeof(MyWish)))
            {
                string myQueuePath = ".\\private$\\myQueue";

                if (!MessageQueue.Exists(myQueuePath))
                {
                    MessageQueue.Create(myQueuePath, false);
                }



                host.Open();
                Console.WriteLine("Server is listening on port 32578");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }

        }
    }
}
