using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;

namespace DDSTP.Repositories
{
    public abstract class BaseWithDeleteRepository<T> : BaseRepository<T> where T : class

{
        protected BaseWithDeleteRepository(dbDDSTPContext context)
            :base (context)
        {
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
        }

    }
}
