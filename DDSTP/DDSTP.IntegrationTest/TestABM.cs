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
            av1.Day = DayOfWeek.Tuesday;

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

            var repo = new ShopPOIRepository(dbContext);

            var shop = repo.GetById(5);

            repo.Delete(shop);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void TestBank()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);


            var av1 = new Availability();
            av1.OpenTime = new TimeSpan(0, 0, 0);
            av1.CloseTime = new TimeSpan(23, 59, 59);
            av1.Day = DayOfWeek.Tuesday;

            var service = new Service();
            service.ServiceName = "la concha de tu hermana";

            var banco = new BankPOI();
            banco.Name = "Banco Superville";
            banco.Geolocation = GeoHelper.PointFromLatLng(-34.581826f, -58.412725f);
            banco.BankServiceAvaibilities.Add(new BankServiceAvailability()
            {
                BankPoi = banco,
                Availability = av1,
                Service = service,
            });

            repo.Add(banco);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void TestUpdateBank()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new POIRepository(dbContext);

            var banco = repo.GetById(6);
            banco.Name = "Banco Superville Cmabiado";

            repo.Update(banco);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void TestDeleteBanco()
        {
            var dbContext = new dbDDSTPContext();

            var repo = new BankPOIRepository(dbContext);

            var banco = repo.GetById(6);

            repo.Delete(banco);
            dbContext.SaveChanges();
        }
    }
}
