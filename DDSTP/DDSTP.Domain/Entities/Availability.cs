using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DDSTP.Domain.Entities
{
    public class Availability
    {
        [Key]
        public int ID { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public DayOfWeek Day { get; set; }

    }
}
