using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    public abstract class Context : DbContext, IContext
    {
        public Context() : base() { }
        public Context(string connectionString) : base(connectionString) { }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
