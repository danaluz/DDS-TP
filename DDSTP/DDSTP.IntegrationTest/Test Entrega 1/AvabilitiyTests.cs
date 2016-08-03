using System.Linq;
using DDSTP.Data;
using DDSTP.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class AvabilitiyTests
    {
        [TestMethod]
        public void ShopPOI_IsAvailible()
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = dbContext.POIs.OfType<ShopPOI>().FirstOrDefault();

            var result = poi1.IsAvailable();

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void BusStopPOI_IsAvailible()
        {
            var poi1 = new BusStopPOI();

            var result = poi1.IsAvailable();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BankPOI_IsAvailible()
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = dbContext.POIs.OfType<BankPOI>().First();

            var result = poi1.IsAvailable();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CGP_IsServiceAvailible()
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = dbContext.POIs.OfType<CGPPOI>().First();

            var result = poi1.IsAvailable("asesoramiento");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CGP_IsAnyServiceAvailible()
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = dbContext.POIs.OfType<CGPPOI>().First();

            var result = poi1.IsAvailable();

            Assert.IsTrue(result);
        }
    }
}
