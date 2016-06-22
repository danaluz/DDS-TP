using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class POIRepository: BaseRepository<POI>
    {
        public POIRepository(dbDDSTPContext context)
            : base(context)
        {
            
        }

        public List<POI> Search(string filtro)
        {
            var result = (from x in context.POIs.AsEnumerable()
                         where x.IsContained(filtro)
                         select x).ToList();
            return result;

        }

        public  List<POI> Search(string filtro, double lat, double lng)
        {
            var result = (from x in context.POIs.AsEnumerable()
                          where x.IsContained(filtro) && x.IsNear(lat,lng)
                          select x).ToList();
            return result;

        }

        public List<POI> SearchNear(double lat, double lng)
        {
            var result = (from x in context.POIs.AsEnumerable()
                          where x.IsNear(lat,lng) && x.IsAvailable()
                          select x).ToList();
            return result;

        }

        
    }
}
