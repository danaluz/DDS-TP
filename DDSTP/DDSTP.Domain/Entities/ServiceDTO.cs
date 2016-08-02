using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
