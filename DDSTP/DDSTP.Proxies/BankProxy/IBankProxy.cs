using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Proxies
{
    public interface IBankProxy
    {
        List<Bank> Search(string name, string service);
    }
}
