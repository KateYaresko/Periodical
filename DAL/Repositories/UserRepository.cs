using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EntityFramework;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class UserRepository<TEntity> : Repository<PeriodicalContext, TEntity>, IRepository<TEntity> where TEntity : class
    {
        //public void UpdateUser(int userId, int editionId)
        //{
        //    var user = Context.Users.Find(userId);
        //    var edition = Context.Editions.Find(editionId);

        //    user.Editions.Add(edition);
        //    edition.Users.Add(edition);


        //    Context.Entry(model).State = EntityState.Modified;
        //    Save();
        //}
    }
}
