using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModels
{
    public class CategoryEdit
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public string BackgroundImgName { get; set; }
        public string HomeImgName { get; set; }
    }
}
