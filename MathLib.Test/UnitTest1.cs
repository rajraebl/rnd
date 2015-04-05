using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLib.Test
{
    using System.Runtime.Remoting.Messaging;
    using Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    /*
     you can run ur unit test from command promt also:
     * Go to Start --> Microsoft Visual Studio 2013--> Visual Studio Tools, and then choose Developer Command Prompt
     * Run "Developer Command Prompt" in admin mode
     * Give command: VSTest.Console.exe E:\myProject\Projects\RnD\MathLib.Test\bin\Debug\mathlib.test.dll to run all the tests in the project
     * Vstest.console.exe E:\myProject\Projects\RnD\MathLib.Test\bin\Debug\mathlib.test.dll /TestCaseFilter:”TestCategory=FakesRequired"
     * 
     */
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            MathClass mc = new MathClass(4, 1);

            int result = mc.add();

            Assert.AreEqual<int>(result, 5);

        }

        [TestMethod]
        public void TestMethod2()
        {

            //MathClass mc = new MathClass(4, 1);

            IMathClass mc = new MathLib.Fakes.StubIMathClass()
            {
                Subs = () => { return 5; }
            };
            //mc.
            //mc.subs = () => 5;
            int result = mc.subs();

            Assert.AreEqual<int>(5, result);

        }

        [TestCategory("FakesRequired")]
        [TestMethod]
        public void shimtest()
        {
            int fixedYear = 2000;
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => { return new DateTime(fixedYear, 1, 1); };

                var pureClassWithoutFakes = new MathClass(1, 2);
                int year = pureClassWithoutFakes.GetTheCurrentYear();

                Assert.AreEqual(year,fixedYear);
            }

        }
    }
}
