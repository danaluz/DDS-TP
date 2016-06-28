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
        public int ID { get; set; }
        public string ServiceName  { get; set; }
    }
}
