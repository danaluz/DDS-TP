using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Proxies
{
    public static class CentroDTOFactory
    {
        public static ObtenerDTO Create()
        {
            return new ObtenerDTOPrecargado();
        }
    }
}
