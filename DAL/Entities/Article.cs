using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgName { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Edition Edition { get; set; }
    }
}
