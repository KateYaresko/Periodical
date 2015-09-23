using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Models;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;

namespace Periodical.Controllers
{
    [AllowAnonymous]
    public class EditionsController : BaseCommonController
    {
        public EditionsController(IEditionsService editionsService, IArticlesService articlesService)
            : base(editionsService, articlesService) { }

        [HttpGet]
        public ActionResult Index(int categoryId = 1)
        {
            Mapper.CreateMap<CategoryDTO, CategoryViewModel>();
            var categories = Mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(editionsService.GetCategories());

            Mapper.CreateMap<EditionDTO, EditionViewModel>();
            var editions = Mapper.Map<IEnumerable<EditionDTO>, List<EditionViewModel>>(editionsService.GetEditionsByCategoryId(categoryId, User.Identity.Name));

            var models = new Tuple<List<CategoryViewModel>, List<EditionViewModel>>(categories, editions);

            ViewBag.ActiveCategory = categoryId;
            ViewBag.ActiveBackground = editionsService.GetBackgroundById(categoryId);
            ViewBag.NavbarEditions = "active";

            return View(models);
        }

        [HttpGet]
        public ActionResult Articles(int editionId, bool isSubscribed)
        {
            Mapper.CreateMap<EditionDTO, EditionViewModel>();
            var edition = Mapper.Map<EditionDTO, EditionViewModel>(articlesService.GetEditionById(editionId));

            Mapper.CreateMap<ArticleDTO, ArticleViewModel>();
            var articles = Mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articlesService.GetArticles(editionId, isSubscribed));

            var models = new Tuple<EditionViewModel, List<ArticleViewModel>, bool>(edition, articles, isSubscribed);

            return View(models);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    editionsService.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
