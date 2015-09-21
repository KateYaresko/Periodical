using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Areas.Security.Models;
using WebMatrix.WebData;
using System.Web.Security;
using BLL.Infrastructure;
using BLL.Interfaces;

namespace Periodical.Areas.Security.Controllers
{
    public class SigninController : BaseSecurityController
    {
        public SigninController(IPeriodicalMembershipProvider membership) : base(membership) { }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.NavbarSignin = "active";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SigninViewModel model, string returnUrl)
        {
            try
            {
                if (membership.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                throw new ValidationException("Invalid Signin", "Signin");             
            }
            catch(ValidationException exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }  
    }
}
