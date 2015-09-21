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
    public class EFUnitOfWork : IUnitOfWork
    {
        private PeriodicalContext db;
        private ArticleRepository<Article> articleRepository ;
        private CategoryRepository<Category> categoryRepository;
        private EditionRepository<Edition> editionRepository;
        private UserRepository<User> userRepository;
        private RoleRepository<Role> roleRepository;

        public EFUnitOfWork()
        {
            db = new PeriodicalContext();
        }

        public EFUnitOfWork(string connectionString)
        {
            db = new PeriodicalContext(connectionString);
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                   // articleRepository = new ArticleRepository<Article>(db);
                    articleRepository = new ArticleRepository<Article>();
                return articleRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                   // categoryRepository = new CategoryRepository<Category>(db);
                    categoryRepository = new CategoryRepository<Category>();
                return categoryRepository;
            }
        }

        public IRepository<Edition> Editions
        {
            get
            {
                if (editionRepository == null)
                    //editionRepository = new EditionRepository<Edition>(db);
                    editionRepository = new EditionRepository<Edition>();
                return editionRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                  //  userRepository = new UserRepository<User>(db);
                    userRepository = new UserRepository<User>();
                return userRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    //  userRepository = new UserRepository<User>(db);
                    roleRepository = new RoleRepository<Role>();
                return roleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
