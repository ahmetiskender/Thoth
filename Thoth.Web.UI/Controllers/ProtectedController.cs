using System;
using System.Collections.Generic;
using System.IO; 
using System.Web.Mvc;
using Thoth.Web.UI.Helper;

namespace Thoth.Web.UI.Controllers
{
    public class ProtectedController : Controller
    {
      
       
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();

            }
        }

    }
}