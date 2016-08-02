using System.Collections.Generic;

namespace DDSTP.Proxies
{
    public interface IBankProxy
    {
        List<Bank> Search(string name, string service);
    }
}
