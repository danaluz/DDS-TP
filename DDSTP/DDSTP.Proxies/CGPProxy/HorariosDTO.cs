﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Proxies
{
    public class HorariosDTO
    {
        public int horarioDesde { get; set; }
        public int horarioHasta { get; set; }
        public int minutosDesde { get; set; }
        public int minutosHasta { get; set; }
        public int nroDiaSemana { get; set; }
    }
}
