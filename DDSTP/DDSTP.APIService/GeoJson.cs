using System.Collections.Generic;
using System.Linq;

namespace DDSTP.APIService
{
    public class GeoJson
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }

        public List<Point> GetPolygonLimits()
        {
            var list = new List<Point>();

            foreach (var primerc in coordinates)
            {
                foreach (var segundoc in primerc)
                {
                    foreach (var tercerc in segundoc)
                    {
                        var p= new Point();
                        p.Longitude = tercerc[0];
                        p.Latitude = tercerc[1];
                        list.Add(p);
                    }
                    
                }
            }


            //chequeo si los primeros y los últimos son iguales, sino se agrega
            var first = list.First();
            var last = list.Last();
            //uso Equals por ser valores double
            if (!first.Longitude.Equals(last.Longitude) || !first.Latitude.Equals(last.Latitude))
            {
                list.Add(first);
            }

            return list;

        }
    }

    public class Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
