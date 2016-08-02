using System.ComponentModel.DataAnnotations;

namespace DDSTP.Domain.Entities
{
    public class Service
    {
        [Key]
        public int ID { get; set; }
        public string ServiceName  { get; set; }
    }
}
