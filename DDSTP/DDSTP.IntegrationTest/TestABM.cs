using System;
using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Domain.Components;
using DDSTP.Domain.Entities;
using DDSTP.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class TestABM
    {
        [TestMethod]
        public void TestAdd()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);
            
            var rubro = new Category();
            rubro.DistanceLess = 800;
            rubro.Name = "librería";

            var av1 = new Availability();
            av1.OpenTime = new TimeSpan(0, 0, 0);
            av1.CloseTime = new TimeSpan(23, 59, 59);
            av1.Day = DayOfWeek.Friday;

            var shop1 = new ShopPOI();
            shop1.Name = "Librería Menganito";
            shop1.Geolocation = GeoHelper.PointFromLatLng(-34.581826f, -58.412725f);
            shop1.Category = rubro;
            shop1.Availabilities.Add(av1);

            repo.Add(shop1);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void TestUpdate()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var shop = repo.GetById(5);
            shop.Name = "Libreria Adan Buenosayres";

            repo.Update(shop);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void TestDelete()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var shop = repo.GetById(5);

            repo.Delete(shop);
            dbContext.SaveChanges();
        }
    }
}
