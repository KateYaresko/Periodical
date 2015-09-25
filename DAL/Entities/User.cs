using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double? Cash { get; set; }
        public bool IsBlocked { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Edition> Editions { get; set; }
        public User()
        {
            Editions = new List<Edition>();
        }
    }
}
