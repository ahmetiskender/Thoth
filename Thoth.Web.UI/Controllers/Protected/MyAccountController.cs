using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thoth.Business.Abstract;
using Thoth.Business.Concrete.Managers;
using Thoth.Web.UI.Models;
using Thoth.Business.MD5;
using System.Web.Security;
using Thoth.Entity.Concrete;
using System.Web.Script.Serialization;

namespace Thoth.Web.UI.Controllers.Protected
{
    public class MyAccountController : ProtectedController
    {
        IUsersService users = new UsersManager();
        Md5Encryption md5 = new Md5Encryption();
        User usr = new User();

        // GET: MyAccount
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login l, string ReturnUrl = "")
        {
            string hash = md5.Encrypt(l.Password);

            #region
            //var user = users.GetAll(x => x.Username.Equals(l.Username) && x.Hash.Equals(hash)).FirstOrDefault();

            //if (user != null)
            //{
            //    FormsAuthentication.SetAuthCookie(user.Username, l.RememberMe);
            //    if (Url.IsLocalUrl(ReturnUrl))
            //    {
            //        return Redirect(ReturnUrl);
            //    }
            //    else
            //    {
            //        return RedirectToAction("MyProfile", "Home");
            //    }
            //}


            //if (ModelState.IsValid)
            //{
            //    var user = users.GetAll(x => x.Username.Equals(l.Username) && x.Hash.Equals(hash)).FirstOrDefault();
            //    if (user != null)
            //    {
            //        FormsAuthentication.SetAuthCookie(l.Username, l.RememberMe);
            //        if (Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //}
            #endregion

            if (ModelState.IsValid)
            {
                var user = users.GetAll(x => x.Username.Equals(l.Username) && x.Hash.Equals(hash)).FirstOrDefault();

                if (user != null)
                {
                    
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string data = js.Serialize(user);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(30), l.RememberMe, data);
                    string encToken = FormsAuthentication.Encrypt(ticket);
                    HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
                    Response.Cookies.Add(authoCookies);
                    //return Redirect(ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.Remove("Password");
            return View(l);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "MyAccount");
        }

        public ActionResult Forget()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forget(Register l)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register l)
        {
            if (!ModelState.IsValid)
            {
                return View(l);

            }

            // kullanıcı getirmeden yapmam lazım parent id artıyo
            var user = new Users();
            user.Name = l.Name;
            user.Surname = l.Surname;
            user.Hash = md5.Encrypt(l.Password);
            user.EMail = l.EMail;
            user.Username = l.Username;
            user.RefUserTypeId = 1;
            
                users.Add(user.Id,user);
            ModelState.Clear();
            ViewBag.Message = l.Name + " " + l.Surname + " kayıt başarılı.";

            return View(l);
        }
    }
}