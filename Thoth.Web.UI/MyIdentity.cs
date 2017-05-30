using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Thoth.Business.Concrete.Managers;
using Thoth.Web.UI.Models;
using Thoth.Business.Abstract;
using Thoth.Business.MD5;

namespace Thoth.Web.UI
{ 
    public class MyIdentity : IIdentity
    {
        IUsersService users = new UsersManager();
        Md5Encryption md5 = new Md5Encryption();

        public IIdentity Identity { get; set; }

        public User User { get; set; }

        public MyIdentity(User user)
        {
            Identity = new GenericIdentity(user.Username);
            var usr = users.GetAll(x => x.Username.Equals(user.Username)).FirstOrDefault();
            if (usr != null)
            {
                user.Username = usr.Username;
                user.UserID = usr.Id;
                user.Password = usr.Hash;
                user.LastName = usr.Surname;
                user.FirstName = usr.Name;
                user.EmailID = usr.EMail;
            }

            User = user;
        }

        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return Identity.IsAuthenticated; }
        }

        public string Name
        {
            get { return Identity.Name; }
        }
    }
}