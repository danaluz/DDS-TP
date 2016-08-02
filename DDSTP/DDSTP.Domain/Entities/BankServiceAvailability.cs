using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDSTP.Domain.Entities
{
    public class BankServiceAvailability
    {
        public virtual BankPOI BankPoi { get; set; }
        public virtual Service Service { get; set; }
        public virtual Availability Availability { get; set; }

        [Key]
        [Column(Order = 0)]
        public int BankPoiId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ServiceId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int AvailabilityId { get; set; }
    }
}
