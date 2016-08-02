using System;
using System.Collections.Generic;
using System.Linq;
using DDSTP.Domain.Entities;

namespace DDSTP.Domain
{
    public class BankPOI : POI
    {
        private const int _fiveBlock = 500;

        public BankPOI()
        {
            BankServiceAvaibilities = new List<BankServiceAvailability>();
            KeyWords = new List<KeyWord>();
        }

        public virtual List<ServiceDTO> Services
        {
            get
            {
                var services = BankServiceAvaibilities.Select(x => x.Service);

                var result = new List<ServiceDTO>();
                foreach (var service in services)
                {
                    var avaibilities = BankServiceAvaibilities.Where(x => x.ServiceId == service.ID).Select(y=>y.Availability).ToList();
                    var item = new ServiceDTO(service, avaibilities);
                    result.Add(item);
                }

                return result;
            }
        }

        public virtual List<BankServiceAvailability> BankServiceAvaibilities { get; set; }

        public override TypeOfPOI Type
        {
            get { return TypeOfPOI.Bank; }

        }

        public override bool IsNear(double lat, double lon)
        {
            var comparer = new POIComparer(_fiveBlock);
            return comparer.AreNear(this, lat, lon);
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
