using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class ShopPOIRepository: BaseWithDeleteRepository<ShopPOI>
    {
        public ShopPOIRepository(dbDDSTPContext context)
            : base(context)
        {            
        }

    }
}
