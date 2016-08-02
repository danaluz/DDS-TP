using System.Collections.Generic;

namespace DDSTP.Proxies
{
    public class ServicioDTO
    {
        public ServicioDTO()
        {
            horarios = new List<HorariosDTO>();
        }
        public string nombreServicio { get; set; }
        public List<HorariosDTO> horarios { get; set; }
    }
}
