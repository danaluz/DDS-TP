using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.Domain
{
   public class POIComparer 
    {
       private int distanceLessThan; 
       
       public POIComparer(int distanceLessThan)
       {
           this.distanceLessThan = distanceLessThan;
       }
        public bool AreNear(POI x, POI y)
        {
            var dist = distance(x.Geolocation.Latitude.GetValueOrDefault(0), x.Geolocation.Longitude.GetValueOrDefault(0), y.Geolocation.Latitude.GetValueOrDefault(0), y.Geolocation.Longitude.GetValueOrDefault(0));

            return dist < distanceLessThan;
        }

        public bool AreNear(POI x, double lat, double lon)
        {
            var dist = distance(x.Geolocation.Latitude.GetValueOrDefault(0), x.Geolocation.Longitude.GetValueOrDefault(0), lat, lon);

            return dist < distanceLessThan;
        }

        private double distance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            dist = dist * 1000;

            return (dist);
        }


        //  This function converts decimal degrees to radians            
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
       
        // This function converts radians to decimal degrees         
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
