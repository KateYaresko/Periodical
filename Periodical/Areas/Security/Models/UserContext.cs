using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Periodical.Areas.Security.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("PeriodicalConnection")
        {
        }

        public DbSet<UserViewModel> Users { get; set; }
    }
}