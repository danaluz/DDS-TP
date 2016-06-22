using System;
using DDSTP.Proxies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = BankProxyFactory.Create();
            var pepe = mock.Search("pepe", "pepita");

            Assert.IsTrue(pepe.Count>0);
        }
    }
}
