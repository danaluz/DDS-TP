using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDSTP.Domain.Entities
{
    public class Service
    {
        public string ServiceName  { get; set; }
        public virtual List<Availability> Availabilities { get; set; }
    }
}
