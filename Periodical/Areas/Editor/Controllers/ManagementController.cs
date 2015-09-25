using AutoMapper;
using BLL.BusinessModels;
using BLL.Interfaces;
using Periodical.Areas.Editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Areas.Editor.Controllers
{
    public class ManagementController : BaseManagementController
    {
        public ManagementController(IEditorService editorService)
            : base(editorService) { }

        [HttpGet]
        public ActionResult Index()
        {
            Mapper.CreateMap<CategoryEdit, CategoryEditViewModel>();
            var categories = Mapper.Map<List<CategoryEdit>, List<CategoryEditViewModel>>(editorService.GetCategories());

            Mapper.CreateMap<EditionEdit, EditionEditViewModel>();
            var editions = Mapper.Map<List<EditionEdit>, List<EditionEditViewModel>>(editorService.GetEditions());

            Mapper.CreateMap<ArticleEdit, ArticleEditViewModel>();
            var articles = Mapper.Map<List<ArticleEdit>, List<ArticleEditViewModel>>(editorService.GetArticles());

            var models = new Tuple<List<CategoryEditViewModel>, List<EditionEditViewModel>, List<ArticleEditViewModel>>(categories, editions, articles);
            ViewBag.NavbarEditionsManagement = "active";
            return View(models);
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryEditViewModel category)
        {
            Mapper.CreateMap<CategoryEditViewModel, CategoryEdit>();
            editorService.CreateCategory(Mapper.Map<CategoryEditViewModel, CategoryEdit>(category));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateEdition(EditionEditViewModel edition)
        {
            Mapper.CreateMap<EditionEditViewModel, EditionEdit>();
            editorService.CreateEdition(Mapper.Map<EditionEditViewModel, EditionEdit>(edition));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateArticle(ArticleEditViewModel article)
        {
            article.DateTime = DateTime.Now;
            Mapper.CreateMap<ArticleEditViewModel, ArticleEdit>();
            editorService.CreateArticle(Mapper.Map<ArticleEditViewModel, ArticleEdit>(article));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCategory(CategoryEditViewModel category)
        {
            Mapper.CreateMap<CategoryEditViewModel, CategoryEdit>();
            editorService.EditCategory(Mapper.Map<CategoryEditViewModel, CategoryEdit>(category));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditEdition(EditionEditViewModel edition)
        {
            Mapper.CreateMap<EditionEditViewModel, EditionEdit>();
            editorService.EditEdition(Mapper.Map<EditionEditViewModel, EditionEdit>(edition));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditArticle(ArticleEditViewModel article)
        {
            article.DateTime = DateTime.Now;
            Mapper.CreateMap<ArticleEditViewModel, ArticleEdit>();
            editorService.EditArticle(Mapper.Map<ArticleEditViewModel, ArticleEdit>(article));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCategory(CategoryEditViewModel category)
        {
            editorService.DeleteCategory(category.CategoryId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteEdition(EditionEditViewModel edition)
        {
            editorService.DeleteEdition(edition.EditionId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteArticle(ArticleEditViewModel article)
        {
            editorService.DeleteArticle(article.ArticleId);
            return RedirectToAction("Index");
        }
    }
}
