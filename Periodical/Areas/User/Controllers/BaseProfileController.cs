using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Areas.User.Controllers
{
    public class BaseProfileController : Controller
    {
        protected IProfileService profileService;

        public BaseProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }
    }
}
