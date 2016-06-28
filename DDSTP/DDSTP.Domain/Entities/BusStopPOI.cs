using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DDSTP.Domain
{
    public class BusStopPOI : POI
    {
        private const int _oneBlock = 100;

        public bool EnReparacion { get; set; }

        public override TypeOfPOI Type
        {
            get { return TypeOfPOI.BusStop;}
            
        }

        public override bool IsNear(double lat, double lon)
        {
            var comparer = new POIComparer(_oneBlock);
            return comparer.AreNear(this, lat, lon);
        }

        public override bool IsAvailable()
        {
            return true;
        }

        public override bool IsContained(string filter)
        {
            return Name.Contains(filter);
        }
    }
}
