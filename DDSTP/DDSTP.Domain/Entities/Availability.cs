using System;
using System.ComponentModel.DataAnnotations;

namespace DDSTP.Domain.Entities
{
    public class Availability
    {
        private DateTime _openTime;
        private DateTime _closeTime;

        [Key]
        public int ID { get; set; }

        public TimeSpan OpenTime
        {
            get { return _openTime.TimeOfDay; }
            set { _openTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, value.Hours, value.Minutes, value.Seconds); }
        }

        public TimeSpan CloseTime
        {
            get { return _closeTime.TimeOfDay; }
            set { _closeTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, value.Hours, value.Minutes, value.Seconds); }
        }

        public DayOfWeek Day { get; set; }

    }
}
