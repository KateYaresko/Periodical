using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EntityFramework;

namespace DAL.Repositories
{
    public class EditionRepository<TEntity> : Repository<PeriodicalContext, TEntity>, IRepository<TEntity> where TEntity : class
    {       
    }
}