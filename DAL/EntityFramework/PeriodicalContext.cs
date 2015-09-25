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
        public PeriodicalContext()
        {
            Database.SetInitializer<PeriodicalContext>(new PeriodicalDbInitializer());
        }
        public PeriodicalContext(string connectionString)
            : base(connectionString) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(i => i.Editions)
                .WithOptional(a => a.Category)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Edition>().HasMany(i => i.Articles)
                .WithOptional(a => a.Edition)
                .WillCascadeOnDelete(true);
        }
    }
}
