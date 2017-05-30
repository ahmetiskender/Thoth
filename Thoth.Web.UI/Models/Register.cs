using System.ComponentModel.DataAnnotations;

namespace Thoth.Web.UI.Models
{
    public class Register
    {
        [Required(ErrorMessage="Lütfen Kullanıcı Adı Giriniz.",AllowEmptyStrings=false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz.", AllowEmptyStrings = false)]
        [DataType( System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz.", AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [Compare("Password", ErrorMessage = "Lütfen Aynı Şifreyi Giriniz.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Lütfen EMail Giriniz.", AllowEmptyStrings = false)]
        public string EMail { get; set; }
    }
}