using System.ComponentModel.DataAnnotations;

namespace DDSTP.Domain
{
    public class Street
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
    }
}
