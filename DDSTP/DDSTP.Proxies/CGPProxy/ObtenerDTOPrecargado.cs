using System.Collections.Generic;

namespace DDSTP.Proxies
{
    class ObtenerDTOPrecargado: IObtenerDTO
    {
        public List<CentroDTO> ObtenerCentros(string location)
        {
            return MockList();
        }

        private List<CentroDTO> MockList()
        {
            var horario= new HorariosDTO();
            horario.horarioDesde = 8;
            horario.minutosDesde = 30;
            horario.horarioHasta = 16;
            horario.minutosHasta = 0;

            var servicio = new ServicioDTO();
            servicio.nombreServicio = "Atencion Ciudadana";
            servicio.horarios.Add(horario);

            var centro1 = new CentroDTO();
            centro1.nroComuna = 1;
            centro1.zonas.Add("Balvanera");
            centro1.zonas.Add("San Cristobal");
            centro1.nombreDirector = "Juan Pepe";
            centro1.domicilioCGP = "Junín 521";
            centro1.telefonoCGP = "4375-0644/45";
            centro1.servicios.Add(servicio);

            var list = new List<CentroDTO>();
            list.Add(centro1);

            return list;
        }
    }
}
