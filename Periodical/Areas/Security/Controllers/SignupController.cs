using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Areas.Security.Models;
using BLL.Interfaces;

namespace Periodical.Areas.Security.Controllers
{
    public class SignupController : BaseSecurityController
    {
        public SignupController(IPeriodicalMembershipProvider membership) : base(membership) { }

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
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        WebSecurity.CreateUserAndAccount(model.Email, model.Password,
            //            new { FirstName = model.FirstName, LastName = model.LastName, Cash = 0, IsBlocked = false });
            //        WebSecurity.Login(model.Email, model.Password);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    catch (MembershipCreateUserException e)
            //    {
            //        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
            //    }
            //}
            return View(model);
        }

    }
}
