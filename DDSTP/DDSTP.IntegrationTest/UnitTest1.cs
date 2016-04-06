using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbContext = new dbDDSTPContext();
            var poi1 = new POI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;
            poi1.Name="Prueba1";
            poi1.Number=15;
            poi1.Type= TypeOfPOI.Bank;

            dbContext.POIs.Add(poi1);
            dbContext.SaveChanges();

        }
    }
}
