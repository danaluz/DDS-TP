using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Domain;
using DDSTP.Domain.Entities;


namespace DDSTP.Test
{
    [TestClass]
    public class POITests
    {
        [TestMethod]
        public void POIComparerBankPOI()
        {
            var poi1 = new BankPOI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;

            var result = poi1.IsNear(-34.581475f, -58.420244f);
            //var comparador = new POIComparer(700);
            //var result = comparador.AreNear(poi1, -34.581475f, -58.420244f);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void POIComparerShopPOI()
        {
            var rubro = new Category();
            rubro.DistanceLess = 800;

            var poi1 = new ShopPOI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;
            poi1.Category = rubro;

            var result = poi1.IsNear(-34.581475f, -58.420244f);
            //estos dos puntos se encuentran aproximadamente 670
            //var result = comparador.AreNear(poi1, -34.581475f, -58.420244f);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void AvaibilityShopPOI()
        {
            var rubro = new Category();
            rubro.DistanceLess = 800;

            var av1 = new Availability();
            av1.OpenTime= new TimeSpan(0,0,0);
            av1.CloseTime = new TimeSpan(7, 0, 0);
            av1.Day= DayOfWeek.Wednesday;

            var poi1 = new ShopPOI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;
            poi1.Category = rubro;
            var lista = new List<Availability>();
            lista.Add(av1);
            poi1.Availabilities = lista;


            var result = poi1.IsAvailable();

            Assert.IsTrue(result);

        }
        [TestMethod]
        public void AvaibilityBusStopOI()
        {
            var poi1 = new BusStopPOI();
            var result = poi1.IsAvailable();

            Assert.IsTrue(result);

        }

    }
}
