using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Domain;
using DDSTP.Domain.Components;
using DDSTP.Domain.Entities;


namespace DDSTP.Test
{
    [TestClass]
    public class POITests
    {
        [TestMethod]
        public void POIComparerBankPOI_IsNotNear()
        {
            var poi1 = new BankPOI();
            poi1.Geolocation = GeoHelper.PointFromLatLng(-34.581828f, -58.412723f);

            var result = poi1.IsNear(-34.581475f, -58.420244f);
            //var comparador = new POIComparer(700);
            //var result = comparador.AreNear(poi1, -34.581475f, -58.420244f);

            Assert.IsFalse(result);

        }




        [TestMethod]
        public void AvaibilityShopPOI()
        {
            var rubro = new Category();
            rubro.DistanceLess = 800;

            var av1 = new Availability();
            av1.OpenTime= new TimeSpan(0,0,0);
            av1.CloseTime = new TimeSpan(7, 0, 0);
            av1.Day = DayOfWeek.Thursday;

            var poi1 = new ShopPOI();
            poi1.Geolocation = GeoHelper.PointFromLatLng(-34.581828f,-58.412723f);
            poi1.Category = rubro;
            poi1.Availabilities.Add(av1);


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

        [TestMethod]
        public void AvaibilityCGPPOI()
        {
            var av1 = new Availability();
            av1.OpenTime = new TimeSpan(0, 0, 0);
            av1.CloseTime = new TimeSpan(24, 0, 0);
            av1.Day = DayOfWeek.Tuesday;

            var service1 = new Service();
            service1.ServiceName = "asesoramiento";
            service1.ID = 1;
            service1.Availabilities.Add(av1);
            
            var poi1 = new CGPPOI();
            poi1.Services.Add(service1);

            var result = poi1.IsAvailable("asesoramiento");

            //ojo con los horarois de open y close, dependiendo el momento del test
            Assert.IsTrue(result);

        }

    }
}
