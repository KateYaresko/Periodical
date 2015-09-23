using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IEditionsService
    {
        List<CategoryDTO> GetCategories();
        List<EditionDTO> GetEditionsByCategoryId(int categoryId, string email);
        string GetBackgroundById(int id);
        void Dispose();
    }
}
