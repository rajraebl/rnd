using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oops
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CallingVirtualMethodInsideConstructorMayGiveUndesiredResult()
        {
            try
            {
                Child c = new Child();
                Console.WriteLine("I am unreachable");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is NullReferenceException);
            }
        }
    }
}
