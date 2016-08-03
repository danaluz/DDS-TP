using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDSTP.Domain
{
    public class KeyWord
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200), Index(IsUnique = true)]
        public string Word { get; set; }
    }
}
