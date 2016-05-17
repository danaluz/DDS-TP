using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DDSTP.Domain.Entities;

namespace DDSTP.Domain
{
    public class CGPPOI : POI
    {
        public CGPPOI()
        {
            this.Services = new List<Service>();
        }

        public virtual Community Community { get; set; }
            
        public virtual List<Service> Services { get; set; }

        public override TypeOfPOI Type
        {
            get { return TypeOfPOI.CGP;}
            
        }

        /// <summary>
        /// Es near cuando pasa x cosa
        /// </summary>
        /// <param name="lat">esta es la latutud considen</param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public override bool IsNear(double lat, double lng)
        {
            return Community.IsInclude(lat, lng);
        }

        
        public override bool IsContained(string filter)
        {
            return Name.Contains(filter) || Services.Any(x => x.ServiceName.Contains(filter));
        }

        public bool IsAvailable(string service)
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;

            var result = this.Services.Any(y => y.ServiceName.Contains(service) && y.Availabilities.Any
                                      (x => nowTime >= x.OpenTime &&
                                      nowTime < x.CloseTime &&
                                      x.Day == nowDay));
            return result;
        }

        public override bool IsAvailable()
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;

            var result = this.Services.Any(y => y.Availabilities.Any
                                      (x => nowTime >= x.OpenTime &&
                                      nowTime < x.CloseTime &&
                                      x.Day == nowDay));
            return result;
        }
    }
}
