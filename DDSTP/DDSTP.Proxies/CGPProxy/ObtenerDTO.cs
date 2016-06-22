using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Proxies;

namespace DDSTP.Proxies
{
    public interface ObtenerDTO
    {
        List<CentroDTO> ObtenerCentros(string location);
    }
}
