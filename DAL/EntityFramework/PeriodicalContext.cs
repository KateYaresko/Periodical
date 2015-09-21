using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EntityFramework
{
    public class PeriodicalContext : Context
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public PeriodicalContext()
        {
            Database.SetInitializer<PeriodicalContext>(new PeriodicalDbInitializer());
        }
        public PeriodicalContext(string connectionString)
            : base(connectionString) {}
    }
}
