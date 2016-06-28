using System;
using System.Linq;
using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Domain.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDSTP.IntegrationTest
{
    [TestClass]
    public class IsNearTests
    {
        [TestMethod]
        public void CGP_IsNear()
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = new CGPPOI();
            poi1.Community = dbContext.Communities.Find(1);

            var result = poi1.IsNear(-34.591151, -58.399175);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ShopPOI_IsNear()
        {
            var dbContext = new dbDDSTPContext();

            //hay un solo ShopPOI actualmente, ver dbcontext
            var poi1 = dbContext.POIs.OfType<ShopPOI>().First();

            var result = poi1.IsNear(-34.581475f, -58.420244f);
            
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void BankPOI_IsNotNear() //las coordenadas no se encuentran a menos de 500 metros
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = dbContext.POIs.OfType<BankPOI>().First();
            
            var result = poi1.IsNear(-34.581475f, -58.420244f);
            //var comparador = new POIComparer(700);
            //var result = comparador.AreNear(poi1, -34.581475f, -58.420244f);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void BusStop_IsNear() //las coordenadas no se encuentran a menos de 500 metros
        {
            var dbContext = new dbDDSTPContext();

            var poi1 = dbContext.POIs.OfType<BusStopPOI>().First();

            var result = poi1.IsNear(-34.593893f, -58.412525f);
            //var comparador = new POIComparer(700);
            //var result = comparador.AreNear(poi1, -34.581475f, -58.420244f);

            Assert.IsTrue(result);
        }
    }
}
