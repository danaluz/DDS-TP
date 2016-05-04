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
            

        public List<Service> Services { get; set; }

        public override TypeOfPOI Type
        {
            get { return TypeOfPOI.CGP;}
            
        }

        public override bool IsNear(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public override bool IsAvailable()
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;

            var result = this.Services.Any(y=>y.Availabilities.Any
                                      (x => nowTime >= x.OpenTime &&
                                      nowTime < x.CloseTime &&
                                      x.Day == nowDay));
            return result;
        }

        public bool IsAvailable(Service service)
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;
            
            var result = this.Services.Any(y => y.ServiceName==service.ServiceName && y.Availabilities.Any
                                      (x => nowTime >= x.OpenTime &&
                                      nowTime < x.CloseTime &&
                                      x.Day == nowDay));
            return result;
        }

        public bool IsAvailable(string service)
        {
            var nowTime = DateTime.Now.TimeOfDay;
            var nowDay = DateTime.Now.DayOfWeek;

            var result = this.Services.Any(y => y.ServiceName == service && y.Availabilities.Any
                                      (x => nowTime >= x.OpenTime &&
                                      nowTime < x.CloseTime &&
                                      x.Day == nowDay));
            return result;
        }
    }
}
