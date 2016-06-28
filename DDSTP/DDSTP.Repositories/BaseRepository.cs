using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;

namespace DDSTP.Repositories
{
    public abstract class BaseRepository<T> where T : class 

{
        protected dbDDSTPContext context;

        protected BaseRepository(dbDDSTPContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Remove(entity);
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }


    }
}
