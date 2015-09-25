using AutoMapper;
using BLL.BusinessModels;
using BLL.Interfaces;
using DAL.Entities;
using DAL.EntityFramework;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EditorService : IEditorService
    {
        private IUnitOfWork Db { get; set; }
        public EditorService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public List<CategoryEdit> GetCategories()
        {
            Mapper.CreateMap<Category, CategoryEdit>();
            return Mapper.Map<IEnumerable<Category>, List<CategoryEdit>>(Db.Categories.GetAll());
        }

        public List<EditionEdit> GetEditions()
        {
            Mapper.CreateMap<Edition, EditionEdit>();
            var editions = Mapper.Map<IEnumerable<Edition>, List<EditionEdit>>(Db.Editions.GetAll());
            foreach(var edition in editions)
            {
                edition.CategoryName = Db.Editions.GetBy(e => e.EditionId == edition.EditionId).FirstOrDefault().Category.Name;
            }
            return editions;
        }

        public List<ArticleEdit> GetArticles()
        {
            Mapper.CreateMap<Article, ArticleEdit>();
            var articles = Mapper.Map<IEnumerable<Article>, List<ArticleEdit>>(Db.Articles.GetAll());
            foreach (var article in articles)
            {
                article.CategoryName = Db.Articles.GetBy(a => a.ArticleId == article.ArticleId).FirstOrDefault().Edition.Category.Name;
                article.EditionName = Db.Articles.GetBy(a => a.ArticleId == article.ArticleId).FirstOrDefault().Edition.Name;
            }
            return articles;
        }

        public void CreateCategory(CategoryEdit category)
        {
            Mapper.CreateMap<CategoryEdit, Category>();
            Db.Categories.Create(Mapper.Map<CategoryEdit, Category>(category));
        }
        public void CreateEdition(EditionEdit edition)
        {           
            Edition new_edition = new Edition()
            {
                Name = edition.Name,
                Price = edition.Price
            };
            Db.Editions.Create(new_edition);

            using (var db = new PeriodicalContext())
            {
                var existedEdition = db.Editions.Where(e => e.Name == new_edition.Name).FirstOrDefault();
                var category = db.Categories.Where(c => c.Name == edition.CategoryName).FirstOrDefault();
                existedEdition.Category = category;
                category.Editions.Add(existedEdition);
                db.SaveChanges();
            }
        }
        public void CreateArticle(ArticleEdit article)
        {
            Article new_article = new Article()
            {
                Title = article.Title,
                Text = article.Text,
                ImgName = article.ImgName,
                DateTime = article.DateTime
            };
            Db.Articles.Create(new_article);

            using (var db = new PeriodicalContext())
            {
                var existedArticle = db.Articles.Where(e => e.Title == new_article.Title).FirstOrDefault();
                var edition = db.Editions.Where(e => e.Name == article.EditionName).FirstOrDefault();
                existedArticle.Edition = edition;
                edition.Articles.Add(existedArticle);
                db.SaveChanges();
            }
        }

        public void EditCategory(CategoryEdit category)
        {
            var existedCategory = Db.Categories.GetByID(category.CategoryId);
            existedCategory.Name = category.Name;
            existedCategory.IconName = category.IconName;
            existedCategory.BackgroundImgName = category.BackgroundImgName;
            existedCategory.HomeImgName = category.HomeImgName;
            Db.Categories.Update(existedCategory);
        }
        public void EditEdition(EditionEdit edition)
        {
            DeleteEdition(edition.EditionId);
            CreateEdition(edition);
        }
        public void EditArticle(ArticleEdit article)
        {
            DeleteArticle(article.ArticleId);
            CreateArticle(article);
        }

        public void DeleteCategory(int categoryId)
        {
            Category category = Db.Categories.GetByID(categoryId);        
            Db.Categories.Delete(category);
        }

        public void DeleteEdition(int editionId)
        {
            Edition edition = Db.Editions.GetByID(editionId);
            Db.Editions.Delete(edition);
        }

        public void DeleteArticle(int articleId)
        {
            Article article = Db.Articles.GetByID(articleId);
            Db.Articles.Delete(article);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
