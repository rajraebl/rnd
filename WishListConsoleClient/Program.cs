using System;
using WishListConsoleClient.WishListServiceReference;

namespace WishListConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Vishal", "Rahul", "Mayur" };
            string[] wishes = { "Prizes", "Books", ".NET Softwares" };

            WishClient[] wishClients = new WishClient[names.Length];

            for (int i = 0; i < wishClients.Length; i++)
            {
                wishClients[i] = new WishClient();
                wishClients[i].SayYourWish(names[i], wishes[i]);
            }
            Console.WriteLine("All Wishes sent successfully");
            Console.ReadLine();
        }
    }
}
