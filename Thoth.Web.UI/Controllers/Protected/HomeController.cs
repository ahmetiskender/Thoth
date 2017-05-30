using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thoth.Business.MD5;
using Thoth.Data.Concrete.EntityFramework;
using Thoth.Entity.Concrete;

namespace Thoth.Web.UI.Controllers.Protected
{
    public class HomeController : ProtectedController
    {
        // GET: Home
        
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize] // This is for Authorize user
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}