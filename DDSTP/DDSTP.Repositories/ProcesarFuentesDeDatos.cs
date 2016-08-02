using System.Linq;
using DDSTP.Data;
using DDSTP.Domain.Components;
using DDSTP.Proxies;
using DDSTP.Repositories;

namespace DDSTP.Domain
{
    public class ProcesarFuentesDeDatos
    {
        private readonly IBankProxy _bankProxy;
        private readonly ILogManager _logManager;
        private readonly User _adminUser;

        public ProcesarFuentesDeDatos(IBankProxy bankProxy, ILogManager logManager, User adminUser)
        {
            _bankProxy = bankProxy;
            _logManager = logManager;
            _adminUser = adminUser;
        }

        public void Procesar(string name, string service)
        {
            var result = _bankProxy.Search(name, service);

            foreach (var b in result)
            {
                var context = new dbDDSTPContext();
                var flag = false;
                var poi =
                    context.POIs.OfType<BankPOI>()
                        .FirstOrDefault(x => x.Geolocation.Latitude == b.x && x.Geolocation.Longitude == b.y);
                if (poi == null)
                {
                    poi = new BankPOI();
                    flag = true;

                }
                poi.Name = b.banco;
                poi.Geolocation = GeoHelper.PointFromLatLng(b.x, b.y);

                var repo = new POIRepository(context, _adminUser, _logManager);
                if (flag)
                {
                    repo.Add(poi);
                }
                else
                {
                    repo.Update(poi);
                }
                context.SaveChanges();
            }
        }

    }
}
