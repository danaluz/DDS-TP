using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Domain;
using DDSTP.Proxies;

namespace DDSTP.Repositories.Commands
{
    public class UpdateShopsCommand : ICommand
    {
        private readonly IShopsProxy _proxy;

        public string Name
        {
            get { return "UpdateShopsCommand"; }
        }

        public UpdateShopsCommand(IShopsProxy proxy)
        {
            _proxy = proxy;
        }

        public void Do()
        {
            var context = new dbDDSTPContext();

            var userRepo = new UserRepository(context);

            var adminUser = userRepo.GetFirstAdminUser();

            var repository = new POIRepository(context, adminUser, new LogManager(new EmailProxy(), 20));

            var newShops = _proxy.GetData();

            foreach (var shopInfo in newShops)
            {
                var myShop = repository.GetShopByName(shopInfo.Name);

                var isNew = myShop == null;

                if (isNew)
                    myShop = new ShopPOI();

                myShop.Name = shopInfo.Name;

                myShop.KeyWords.Clear();
                foreach (var keyword in shopInfo.Keywords)
                {
                    if (myShop.KeyWords.All(x => x.Word != keyword))
                        myShop.KeyWords.Add(new KeyWord() { Word = keyword });
                }

                if (isNew)
                    repository.Add(myShop);
                else
                    repository.Update(myShop);

                context.SaveChanges();
            }
        }

        public void Undo()
        {
            // Do nothing
        }
    }
}
