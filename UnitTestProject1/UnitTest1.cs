using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void verifyJSONResponse()
        {
            var response = "{\"Status\":0,\"SessionKey\":"1234",\"UserType\":0,\"Message\":\"Successfully authenticated.\"}";

        }
    }

    public class CompanyBankLocation
    {
        public int CompanyBankLocationID { get; set; }
        public int CompanyID { get; set; }
        public int BankLocationID { get; set; }
        public string PaymentMethod { get; set; }
    }
}
