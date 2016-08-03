using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Proxies.RemovePOIProxy
{
    class RemovePOIProxyMock : IRemovePOIProxy
    {
        public RemovePOIInfo GetPOIToRemove()
        {
            return MockPOI();
        }

        private RemovePOIInfo MockPOI()
        {
            var poiToRemove = new RemovePOIInfo();
            poiToRemove.filtro = "114";
            poiToRemove.date = DateTime.Now;

            return poiToRemove;

        }
    }
}
