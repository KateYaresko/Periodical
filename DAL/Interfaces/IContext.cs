using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.EntityFramework
{
    interface IContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
