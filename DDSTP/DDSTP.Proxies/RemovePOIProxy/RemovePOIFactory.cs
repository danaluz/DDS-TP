using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Proxies.RemovePOIProxy
{
    public static class RemovePOIFactory
    {
        public static IRemovePOIProxy Create()
        {
            return new RemovePOIProxyMock();
        }
    }
}
