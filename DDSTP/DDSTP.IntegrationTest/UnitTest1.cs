using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Repositories;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]//Test de búsqueda de un servicio, con datos ya hardcodeados
        public void TestMethod1()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.Search("Santander");

            Assert.IsTrue(result.Count==1);


        }

        [TestMethod]
        public void TestMethod2()
        {
            var dbContext = new dbDDSTPContext();

            var comu = dbContext.Communities.Find(3);


            Assert.IsFalse(comu.Polygon.IsEmpty);


        }
    }
}
