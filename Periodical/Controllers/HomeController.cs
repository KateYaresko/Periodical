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
    public class HomeController : BaseCommonController
    {
        public HomeController(IEditionsService editionsService)
            : base(editionsService) { }

        [HttpGet]
        public ActionResult Index()
        {
            Mapper.CreateMap<CategoryDTO, CategoryViewModel>();
            var categories = Mapper.Map<List<CategoryDTO>, List<CategoryViewModel>>(editionsService.GetCategories());
            ViewBag.NavbarHome = "active";

            return View(categories);
        }
    }
}
