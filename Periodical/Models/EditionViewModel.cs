using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodical.Models
{
    public class EditionViewModel
    {
        public int EditionId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsSubscribed { get; set; }
    }
}