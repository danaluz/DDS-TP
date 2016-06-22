using System;
using DDSTP.Data;
using DDSTP.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Busqueda_POIS_por_Texto_y_Cercania()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.Search("114",-34.593942f, -58.412321f);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
