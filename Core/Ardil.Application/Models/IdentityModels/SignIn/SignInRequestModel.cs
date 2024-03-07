using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Models.IdentityModels.SignIn
{
    public class SignInRequestModel
    {
        [Required(ErrorMessage = "Email veya Kullanıcı Adı Giriniz")]
        public string? UserNameOrEmail { get; set; }
        [Required(ErrorMessage = "Şifrenizi Giriniz")]
        public string? Password { get; set; } 
    }
}
