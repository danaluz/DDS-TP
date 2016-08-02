using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class POIRepository : BaseRepository<POI>
    {
        private readonly User _loggedInUser;
        private readonly ILogManager _log;

        public POIRepository(dbDDSTPContext context, User loggedInUser, ILogManager log)
            : base(context)
        {
            _loggedInUser = loggedInUser;
            _log = log;
        }

        public List<POI> Search(string filtro)
        {
            var watch = Stopwatch.StartNew();

            var result = (from x in context.POIs.AsEnumerable()
                         where x.IsContained(filtro)
                         select x).ToList();

            _log.LogSearch(context, _loggedInUser, string.Format("term:{0}", filtro), watch.Elapsed, result.Count);

            return result;

        }

        public  List<POI> Search(string filtro, double lat, double lng)
        {
            var watch = Stopwatch.StartNew();

            var result = (from x in context.POIs.AsEnumerable()
                          where x.IsContained(filtro) && x.IsNear(lat,lng)
                          select x).ToList();

            _log.LogSearch(context, _loggedInUser, string.Format("term:{0} - latitude:{1} - longitude:{2}", filtro, lat, lng), watch.Elapsed, result.Count);

            return result;

        }

        public List<POI> SearchNear(double lat, double lng)
        {
            var watch = Stopwatch.StartNew();

            var result = (from x in context.POIs.AsEnumerable()
                          where x.IsNear(lat,lng) && x.IsAvailable()
                          select x).ToList();

            _log.LogSearch(context, _loggedInUser, string.Format("latitude:{0} - longitude:{1}", lat, lng), watch.Elapsed, result.Count);

            return result;
        } 
    }
}
