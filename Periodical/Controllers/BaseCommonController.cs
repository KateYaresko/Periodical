using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Controllers
{
    public class BaseCommonController : Controller
    {
        protected IEditionsService editionsService;
        protected IArticlesService articlesService;

        public BaseCommonController(IEditionsService editionsService, IArticlesService articlesService)
        {
            this.editionsService = editionsService;
            this.articlesService = articlesService;
        }

        public BaseCommonController(IEditionsService editionsService)
        {
            this.editionsService = editionsService;
        }
    }
}
