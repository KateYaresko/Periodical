using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Edition
    {
        public int EditionId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public Edition()
        {
            Users = new List<User>();
            Articles = new List<Article>();
        }
    }
}
