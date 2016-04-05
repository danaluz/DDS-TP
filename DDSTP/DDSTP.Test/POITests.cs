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
            poi1.Latitude = -34.580442f;
            poi1.Longitude = -58.411705f;

            var poi2 = new POI();
            poi2.Latitude = -34.580358f;
            poi2.Longitude = -58.411973f;

            var result = poi1.IsNearFrom(30, poi2);
            Assert.IsTrue(result);
           
        }
    }
}
