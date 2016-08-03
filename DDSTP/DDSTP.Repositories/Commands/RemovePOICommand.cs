using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Proxies;
using DDSTP.Proxies.RemovePOIProxy;

namespace DDSTP.Repositories.Commands
{
    public class RemovePOICommand: ICommand
    {
        private readonly IRemovePOIProxy _proxy;

        public string Name {
            get { return "RemovePOICommand"; }
        }

        public RemovePOICommand(IRemovePOIProxy proxy)
        {
            _proxy = proxy;
        }

        public void Do()
        {
            var context = new dbDDSTPContext();

            var userRepo = new UserRepository(context);

            var adminUser = userRepo.GetFirstAdminUser();

            var repository = new POIRepository(context, adminUser, new LogManager(new EmailProxy(), 20));

            var poiToDelete = _proxy.GetPOIToRemove();

            if (poiToDelete != null)
            {
                var poi = repository.Search(poiToDelete.filtro);

                foreach (var poi1 in poi)
                {
                    repository.Delete(poi1);
                    context.SaveChanges();
                }

                
            }

        }
    }
}
