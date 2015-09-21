using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EditionsService : IEditionsService
    {
        private IUnitOfWork Db { get; set; }

        public EditionsService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public List<CategoryDTO> GetCategories()
        {
            Mapper.CreateMap<Category, CategoryDTO>();
            List<CategoryDTO> categories = Mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Db.Categories.GetAll());
            return categories;
        }

        public List<EditionDTO> GetEditionsByCategoryId(int categoryId)
        {
            Mapper.CreateMap<Edition, EditionDTO>();
            return Mapper.Map<IEnumerable<Edition>, List<EditionDTO>>(Db.Editions.GetBy(edition => edition.Category.CategoryId == categoryId));
        }

        public string GetBackgroundById(int id)
        {
            Mapper.CreateMap<Category, CategoryDTO>();
            List<CategoryDTO> category = Mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Db.Categories.GetBy(c => c.CategoryId == id));
            return category[0].BackgroundImgName;
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
