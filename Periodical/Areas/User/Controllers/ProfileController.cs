using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Periodical.Models;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;

namespace Periodical.Areas.User.Controllers
{
    [Authorize]
    public class ProfileController : BaseProfileController
    {
        public ProfileController(IProfileService profileService)
            : base(profileService) { }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.NavbarProfile = "active";
            return View();
        }

    }
}
