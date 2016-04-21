using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DDSTP.Domain.Entities
{
    public class Service
    {
        [Key]
        public int  ID { get; set; }
        public Service()
        {
            this.Availabilities = new List<Availability>();
        }
        public string ServiceName  { get; set; }
        public virtual List<Availability> Availabilities { get; set; }
    }
}
