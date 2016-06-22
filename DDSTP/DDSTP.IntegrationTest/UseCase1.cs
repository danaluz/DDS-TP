using System;
using DDSTP.Data;
using DDSTP.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class UseCase1
    {
        [TestMethod]
        public void Consultar_Disponibilidad_Punto_de_Interés()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.SearchNear(-34.593942f, -58.412321f);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
