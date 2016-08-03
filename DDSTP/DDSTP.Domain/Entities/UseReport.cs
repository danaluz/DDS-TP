using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDSTP.Domain
{
    public class UseReport
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public string Filter { get; set; }

        public TimeSpan TimeTaken { get; set; }

        public int ResultsCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
