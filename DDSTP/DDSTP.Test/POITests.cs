using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDSTP.Domain;


namespace DDSTP.Test
{
    [TestClass]
    public class POITests
    {
        [TestMethod]
        public void POIComparer()
        {
            var poi1 = new POI();
            poi1.Latitude = -34.581828f;
            poi1.Longitude = -58.412723f;

            var poi2 = new POI();
            poi2.Latitude = -34.581475f;
            poi2.Longitude = -58.420244f;

            var comparador = new POIComparer(700);
            var result = comparador.AreNear(poi1, poi2);

            Assert.IsTrue(result);

        }

    }
}
