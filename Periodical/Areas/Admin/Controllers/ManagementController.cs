using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Areas.Admin.Controllers
{
    [Authorize]
    public class ManagementController : BaseManagementController
    {
        public ActionResult Index()
        {
            ViewBag.NavbarManagement = "active";
            return View();
        }

    }
}
