using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class BusStopPOIRepository: BaseWithDeleteRepository<ShopPOI>
    {
        public BusStopPOIRepository(dbDDSTPContext context)
            : base(context)
        {            
        }

    }
}
