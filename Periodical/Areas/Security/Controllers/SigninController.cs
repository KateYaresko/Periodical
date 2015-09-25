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
        public SigninController(IPeriodicalMembershipProvider membership, IAccountService accountService) : base(membership, accountService) { }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.LoginIsFailed = false;
            if (TempData["LoginIsFailed"] != null)
                ViewBag.LoginIsFailed = TempData["LoginIsFailed"];

            ViewBag.UserIsBlocked = false;
            if (TempData["UserIsBlocked"] != null)
                ViewBag.UserIsBlocked = TempData["UserIsBlocked"];

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.NavbarSignin = "active";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SigninViewModel model, string returnUrl)
        {
            TempData["LoginIsFailed"] = false;
            TempData["UserIsBlocked"] = false;
            try
            {
                if (membership.ValidateUser(model.Email, model.Password))
                {
                    if (accountService.UserIsBlock(model.Email))
                    {
                        TempData["UserIsBlocked"] = true;
                        return RedirectToAction("Index");
                    }
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                throw new ValidationException("Invalid Signin", "Signin");             
            }
            catch(ValidationException exception)
            {
                TempData["LoginIsFailed"] = true;
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
