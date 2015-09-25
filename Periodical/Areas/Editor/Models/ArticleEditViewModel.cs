using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Areas.Editor.Models
{
    public class ArticleEditViewModel
    {
        public int ArticleId { get; set; }
        public string CategoryName { get; set; }
        public string EditionName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgName { get; set; }
        public DateTime DateTime { get; set; }

    }
}