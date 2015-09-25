using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Periodical.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class ManagementController : BaseManagementController
    {
        public ManagementController(IAdminService adminService)
            : base(adminService) { }

        [HttpGet]
        public ActionResult Index()
        {
            Mapper.CreateMap<UserDTO, UserViewModel>();
            List<UserViewModel> users = Mapper.Map<List<UserDTO>, List<UserViewModel>>(adminService.GetUsers());
            var models = new Tuple<List<UserViewModel>>(users);
            ViewBag.NavbarUsersManagement = "active";
            return View(models);
        }

        [HttpPost]
        public ActionResult Block(UserViewModel models)
        {
            return RedirectToAction("Index");
        }

    }
}
