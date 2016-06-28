using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Domain.Components;
using DDSTP.Proxies;
using DDSTP.Repositories;

namespace DDSTP.Domain
{
    public class ProcesarFuentesDeDatos
    {
        private readonly IBankProxy _bankProxy;

        public ProcesarFuentesDeDatos(IBankProxy bankProxy)
        {
            _bankProxy = bankProxy;
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
                
                var repo = new POIRepository(context);
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
