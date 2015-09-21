﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {
        private TContext entities = new TContext();
        public TContext Context
        {
            get { return entities; }
            set { entities = value; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).AsQueryable();
        }
        public virtual TEntity GetByID(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        public virtual void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual int Count()
        {
            return Context.Set<TEntity>().Count();
        }
    }
}