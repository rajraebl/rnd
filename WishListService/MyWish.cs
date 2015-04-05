using System;


namespace WishListService
{
    public class MyWish : IWish
    {
        public void SayYourWish(string wisherName, string yourWish)
        {
            Console.WriteLine("Client (Wisher): " + wisherName + " wish is :" + yourWish);
        }
    }
}
