using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Periodical.Areas.Editor.Controllers
{
    public class BaseManagementController : Controller
    {
        protected IEditorService editorService;

        public BaseManagementController(IEditorService editorService)
        {
            this.editorService = editorService;
        }
    }
}
