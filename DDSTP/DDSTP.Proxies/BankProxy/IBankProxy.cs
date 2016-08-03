using System.Collections.Generic;

namespace DDSTP.Proxies
{
    public interface IBankProxy
    {
        List<BankInfo> Search(string name, string service);
    }
}
