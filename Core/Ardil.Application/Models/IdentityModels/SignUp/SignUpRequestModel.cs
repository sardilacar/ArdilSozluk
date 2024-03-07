using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Models.IdentityModels.SignUp
{
    public class SignUpRequestModel
    {

        
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "İsim Giriniz")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Soyisim Giriniz")]
        public required string Surname { get; set; }

        [Required(ErrorMessage = "Email Giriniz")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password Giriniz")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Şifrenizi Tekrar Giriniz")]
        public required string RepeatPassword { get; set; }
    }
}
