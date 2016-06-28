using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DDSTP.Domain.Entities
{
    [NotMapped]
    public class ServiceDTO
    {
        public ServiceDTO(Service service, List<Availability> avaibilities)
        {
            this.ID = service.ID;
            this.ServiceName = service.ServiceName;
            this.Availabilities = avaibilities;
        }
        public int ID { get; set; }
        public string ServiceName  { get; set; }
        public virtual List<Availability> Availabilities { get; set; }
    }
}
