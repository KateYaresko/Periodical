using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Areas.Editor.Models
{
    public class EditionEditViewModel
    {
        public int EditionId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}