using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Proxies
{
    public static class BankProxyFactory
    {
        public static IBankProxy Create()
        {
            return new BankProxyMock();
        }
    }
}
