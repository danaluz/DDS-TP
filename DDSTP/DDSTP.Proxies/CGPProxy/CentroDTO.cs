using System.Collections.Generic;

namespace DDSTP.Proxies
{
    public class CentroDTO
    {
        public CentroDTO()
        {
            zonas = new List<string>();
            servicios = new List<ServicioDTO>();
        }
        public string domicilioCGP { get; set; }
        public string nombreDirector { get; set; }
        public int nroComuna { get; set; }
        public string telefonoCGP { get; set; }
        public List<string> zonas { get; set; }
        public List<ServicioDTO> servicios { get; set; }
    }
}
