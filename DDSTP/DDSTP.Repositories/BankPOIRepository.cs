using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class BankPOIRepository: BaseWithDeleteRepository<BankPOI>
    {
        public BankPOIRepository(dbDDSTPContext context)
            : base(context)
        {            
        }

        public override void Delete(BankPOI entity)
        {
            context.BankServiceAvailabilities.RemoveRange(entity.BankServiceAvaibilities);
            base.Delete(entity);
        }
    }
}
