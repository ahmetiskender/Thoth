using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Thoth.Web.UI.Helper;
using Thoth.Web.UI.Infrastructure;
using System.Web.Security;
using System.Web.Script.Serialization;
using Thoth.Web.UI.Models;

namespace Thoth.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear(); 
            //View Engine Here.
            ViewEngines.Engines.Add(new ViewEngine());
            //move to languages.config
            //LanguageHelper.LoadKeys();

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
        protected void Application_PostAuthenticateRequest()
        {
            HttpCookie authoCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authoCookies != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
                JavaScriptSerializer js = new JavaScriptSerializer();
                User user = js.Deserialize<User>(ticket.UserData);
                MyIdentity myIdentity = new MyIdentity(user);
                MyPrincipal myPrincipal = new MyPrincipal(myIdentity);
                HttpContext.Current.User = myPrincipal;
            }
        }
    }
}
