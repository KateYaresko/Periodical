using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EntityFramework;
using DAL.Entities;

namespace DAL.Repositories
{
    public class ArticleRepository<TEntity> : Repository<PeriodicalContext, TEntity>, IRepository<TEntity> where TEntity : class
    {
    }
}
