using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Category> Categories { get; }
        IRepository<Edition> Editions { get; }
        IRepository<Article> Articles { get; }
        IRepository<Role> Roles { get; }
        void Save();
    }
}
