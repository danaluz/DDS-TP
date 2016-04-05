using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Domain;

namespace DDSTP.Test
{
    [TestClass]
    public class POITests
    {
        [TestMethod]
        public void CompareTwoPOIs()
        {
            var poi1 = new POI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;

            var poi2 = new POI();
            poi2.Latitude = -34.581475f;
            poi2.Longitude = -58.420244f;

            var result = poi1.IsNearFrom(150, poi2);
            Assert.IsTrue(result);
           
        }

        [TestMethod]
        public void DistanceBetweenTwoPointsTest()
        {
            var poi1 = new POI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;

            var poi2 = new POI();
            poi2.Latitude = -34.581475f;
            poi2.Longitude = -58.420244f;

            
            var result = DistanceBetweenTwoPoints.distance(poi1.Latitude, poi1.Longitude, poi2.Latitude, poi2.Longitude);

            Assert.IsTrue(result < 700);

        }

        [TestMethod]
        public void IsNearFromTest()
        {
            var poi1 = new POI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;

            var poi2 = new POI();
            poi2.Latitude = -34.581475f;
            poi2.Longitude = -58.420244f;

            var result = poi1.IsNearFrom(600, poi2); 

            Assert.IsTrue(result);

        }




    }
}
