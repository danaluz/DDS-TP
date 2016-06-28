using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
