using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Areas.Admin.Controllers
{
    public class BaseManagementController : Controller
    {
        protected IAdminService adminService;

        public BaseManagementController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
    }
}
