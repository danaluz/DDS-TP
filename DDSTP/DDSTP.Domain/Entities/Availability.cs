using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDSTP.Domain.Entities
{
    public class Availability
    {
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public DayOfWeek Day { get; set; }

    }
}
