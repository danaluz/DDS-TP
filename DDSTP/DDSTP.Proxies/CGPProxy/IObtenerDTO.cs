using System.Collections.Generic;

namespace DDSTP.Proxies
{
    public interface IObtenerDTO
    {
        List<CentroDTO> ObtenerCentros(string location);
    }
}
