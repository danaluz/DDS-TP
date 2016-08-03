using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class CGPPOIRepository: BaseWithDeleteRepository<CGPPOI>
    {
        public CGPPOIRepository(dbDDSTPContext context)
            : base(context)
        {            
        }

        public override void Delete(CGPPOI entity)
        {
            context.CgpServiceAvailabilities.RemoveRange(entity.CGPServiceAvailabilities);
            base.Delete(entity);
        }
    }
}
