using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Areas.Editor.Models
{
    public class CategoryEditViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public string BackgroundImgName { get; set; }
        public string HomeImgName { get; set; }
    }
}