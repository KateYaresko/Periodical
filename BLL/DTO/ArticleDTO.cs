using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ImgName { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}
