using DDSTP.Proxies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class Test_API_Bank_Mock
    {
        [TestMethod]
        public void Test_ProxyBank()
        {
            var mock = BankProxyFactory.Create();
            var result = mock.Search("Banco de la Plaza", "extracciones");

            Assert.IsTrue(result.Count==2);
        }
    }
}
