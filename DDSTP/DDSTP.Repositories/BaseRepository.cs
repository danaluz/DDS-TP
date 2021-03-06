﻿using System.Data.Entity;
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

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}
