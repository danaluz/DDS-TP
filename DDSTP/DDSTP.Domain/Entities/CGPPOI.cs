﻿using System;
using System.Collections.Generic;
using System.Linq;
using DDSTP.Domain.Entities;

namespace DDSTP.Domain
{
    public class CGPPOI : POI
    {
        public CGPPOI()
        {
            CGPServiceAvailabilities = new List<CGPServiceAvailability>();
            KeyWords = new List<KeyWord>();
        }

        public virtual List<ServiceDTO> Services
        {
            get
            {
                var services = CGPServiceAvailabilities.Select(x => x.Service);

                var result = new List<ServiceDTO>();
                foreach (var service in services)
                {
                    var avaibilities = CGPServiceAvailabilities.Where(x => x.ServiceId == service.ID).Select(y => y.Availability).ToList();
                    var item = new ServiceDTO(service, avaibilities);
                    result.Add(item);
                }

                return result;
            }
        }

        public virtual List<CGPServiceAvailability> CGPServiceAvailabilities { get; set; }
        
        public virtual Community Community { get; set; }
        
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
            //ejecutar load
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
