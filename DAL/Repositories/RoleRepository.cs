using DAL.EntityFramework;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoleRepository<TEntity> : Repository<PeriodicalContext, TEntity>, IRepository<TEntity> where TEntity : class
    { }
}
