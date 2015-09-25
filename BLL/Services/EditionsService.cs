using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.EntityFramework;
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

        public List<EditionDTO> GetEditionsByCategoryId(int categoryId, string email, ref bool isAvailable)
        {
            var editionsEntity = Db.Editions.GetBy(edition => edition.Category.CategoryId == categoryId).ToList();
            Mapper.CreateMap<Edition, EditionDTO>();
            var editions = Mapper.Map<List<Edition>, List<EditionDTO>>(editionsEntity);

            if(email != "" && email != null)
            {
                User user = Db.Users.GetBy(u => u.Email == email).FirstOrDefault();
                for (int i = 0; i < editionsEntity.Count(); i++)
                {
                    foreach(var edition in user.Editions)
                    {
                        if (edition.Name == editionsEntity[i].Name)
                        {
                            editions[i].IsSubscribed = true;
                        }
                    }
                }
                isAvailable = true;
            }
                    
            return editions;
        }

        public bool SibscribeUser(int editionId, string email, ref int categoryId)
        {
            using(var db = new PeriodicalContext())
            {               
                var user = db.Users.Where(u => u.Email == email).FirstOrDefault();
                var edition = db.Editions.Find(editionId);
                categoryId = edition.Category.CategoryId;
                if (user.Cash >= edition.Price)
                {
                    user.Editions.Add(edition);
                    edition.Users.Add(user);
                    user.Cash -= edition.Price;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
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
