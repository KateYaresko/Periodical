using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class EditionEdit
    {
        public int EditionId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
