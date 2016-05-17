using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DDSTP.Domain.Entities;

namespace DDSTP.Domain
{
    public class ShopPOI : POI
    {
        public ShopPOI()
        {
            this.Availabilities = new List<Availability>();
        }


        public virtual Category Category { get; set; }
        public virtual List<Availability> Availabilities { get; set; }

        public override TypeOfPOI Type
        {
            get { return TypeOfPOI.Shop; }

        }

        public override bool IsNear(double lat, double lon)
        {
            var comparer = new POIComparer(this.Category.DistanceLess);
            return comparer.AreNear(this, lat, lon);
        }

        public override bool IsAvailable()
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;

            var result = this.Availabilities
                            .Any(x => nowTime >= x.OpenTime && 
                                      nowTime < x.CloseTime && 
                                      x.Day == nowDay);

            return result;
        }

        public override bool IsContained(string filter)
        {
            return Name.Contains(filter) || Category.Name.Contains(filter);
        }
    }
}
