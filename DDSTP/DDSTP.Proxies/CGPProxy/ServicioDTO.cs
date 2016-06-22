using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
