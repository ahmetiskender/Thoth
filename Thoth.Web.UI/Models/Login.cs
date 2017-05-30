using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thoth.Web.UI.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz.", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}