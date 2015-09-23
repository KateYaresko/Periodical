using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Models;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using Periodical.Areas.User.Models;
using BLL.BusinessModels;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Periodical.Areas.User.Controllers
{
    [Authorize(Roles = "Admin,Editor,User")]
    public class ProfileController : BaseProfileController
    {
        public ProfileController(IProfileService profileService)
            : base(profileService) { }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.PasswordIsValid = "";
            ViewBag.PasswordError = "";
            if(TempData["PasswordIsValid"] != null)
            {
                ViewBag.PasswordIsValid = TempData["PasswordIsValid"].ToString();
            }
            if(TempData["PasswordError"] != null)
            {
                ViewBag.PasswordError = TempData["PasswordError"].ToString();
            }
            ViewBag.NavbarProfile = "active";
            //var a = 
            return View(GetModels());
        }

        [HttpPost]
        public ActionResult ChangeFirstName(string firstName)
        {
            profileService.ChangeFirstName(firstName, User.Identity.Name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangeLastName(string lastName)
        {
            profileService.ChangeLastName(lastName, User.Identity.Name);
            return RedirectToAction("Index");
        }


        private Tuple<UserViewModel, List<Tuple<string, string>>, ChangePasswordViewModel> GetModels()
        {
            Mapper.CreateMap<UserDTO, UserViewModel>();
            UserViewModel user = Mapper.Map<UserDTO, UserViewModel>(profileService.GetUserByEmail(User.Identity.Name));


            Mapper.CreateMap<UserEdition, UserEditionViewModel>();
            List<UserEditionViewModel> userEditions = Mapper.Map<List<UserEdition>, List<UserEditionViewModel>>(profileService.GetUserEditions(user.UserId));
            List<Tuple<string, string>> userEditionsAndCategories = new List<Tuple<string, string>>();
            foreach(var element in userEditions)
            {
                userEditionsAndCategories.Add(new Tuple<string,string>(element.CategoryName, element.EditionName));
            }

            var viewModel = new ChangePasswordViewModel();

            return new Tuple<UserViewModel, List<Tuple<string, string>>, ChangePasswordViewModel>(user, userEditionsAndCategories, viewModel);
        }

        [HttpPost]
        public ActionResult AddCash(double cash)
        {
            profileService.AddCash(cash, User.Identity.Name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            bool isValid = profileService.ChangePassword(model.OldPassword, model.NewPassword, User.Identity.Name);
            TempData["PasswordIsValid"] = "true";
            TempData["PasswordError"] = "";
            if(!isValid)
            {
                TempData["PasswordIsValid"] = "false";
                TempData["PasswordError"] = "Password change failed: current password is incorrect. Please, try again.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAccount(int userId)
        {
            profileService.DeleteAccount(userId);
            return RedirectToAction("Signout", "Signin", new { area = "Security" });
        }
    }
}
