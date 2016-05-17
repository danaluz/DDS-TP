using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace DDSTP.Domain
{
    public abstract class POI
    {
        [Key]
        public int ID { get; set; }
        public DbGeography Geolocation { get; set; }
        public string Name { get; set; }
        public virtual Street MainStreet { get; set; }
        public int? Number { get; set; }
        public abstract TypeOfPOI Type { get; }
        public abstract bool IsNear(double lat, double lon);
        public abstract bool IsAvailable();
        public abstract bool IsContained(string filter);
    }
}