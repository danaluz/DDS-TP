using System;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Domain.Components;
using DDSTP.Domain.Entities;
using DDSTP.Repositories;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void Search_InName()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.Search("Santander");

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void Search_Number()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.Search("114");

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void Search_ServiceCGP()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.Search("asesoramiento");

            Assert.IsTrue(result.Count == 1);
        }

        [TestMethod]
        public void Search_CategoryShop()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var result = repo.Search("librería");

            Assert.IsTrue(result.Count == 1);
        }

    }
}
