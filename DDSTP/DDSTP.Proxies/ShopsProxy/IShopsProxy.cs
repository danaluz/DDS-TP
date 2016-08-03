using System.Collections.Generic;
using DDSTP.Proxies.ShopsProxy;

namespace DDSTP.Proxies
{
    public interface IShopsProxy
    {
        List<ShopInfo> GetData();
    }
}
