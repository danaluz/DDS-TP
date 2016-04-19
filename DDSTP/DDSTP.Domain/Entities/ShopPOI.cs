using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DDSTP.Domain.Entities;

namespace DDSTP.Domain
{
    public class ShopPOI : IPOI
    {
        [Key]
        public int ID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
        public virtual Street MainStreet { get; set; }
        public int? Number { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Availability> Availabilities { get; set; }

        public TypeOfPOI Type
        {
            get { return TypeOfPOI.Shop; }

        }

        public bool IsNear(double lat, double lon)
        {
            var comparer = new POIComparer(this.Category.DistanceLess);
            return comparer.AreNear(this, lat, lon);
        }

        public bool IsAvailable()
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;

            var result = this.Availabilities
                            .Any(x => nowTime >= x.OpenTime && 
                                      nowTime < x.CloseTime && 
                                      x.Day == nowDay);

            return result;
        }
    }
}
