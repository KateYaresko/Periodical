using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Areas.Security.Models;
using BLL.Interfaces;
using AutoMapper;
using BLL.DTO;

namespace Periodical.Areas.Security.Controllers
{
    public class SignupController : BaseSecurityController
    {
        public SignupController(IPeriodicalMembershipProvider membership, IAccountService accountService) : base(membership, accountService) { }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.NavbarSignup = "active";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Mapper.CreateMap<SignupViewModel, UserDTO>();
            accountService.CreateUser(Mapper.Map<SignupViewModel, UserDTO>(model));
            return RedirectToAction("Index", "Signin", new { area = "Security" });
        }

    }
}
