using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public string BackgroundImgName { get; set; }
        public string HomeImgName { get; set; }
        public virtual ICollection<Edition> Editions { get; set; }
        public Category()
        {
            Editions = new List<Edition>();
        }
    }
}
