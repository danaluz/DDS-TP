using System.ComponentModel.DataAnnotations;

namespace DDSTP.Domain.Entities
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int DistanceLess { get; set; }
    }
}
