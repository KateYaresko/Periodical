using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Func<TEntity, bool> predicate);
        TEntity GetByID(int id);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        int Count();
    }
}
