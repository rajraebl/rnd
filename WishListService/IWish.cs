using System;
using System.ServiceModel;

namespace WishListService
{
    [ServiceContract]
    public interface IWish
    {
        [OperationContract(IsOneWay = true)]
        void SayYourWish(string wisherName, string yourWish);
    }
}
