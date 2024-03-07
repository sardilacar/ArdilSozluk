using Ardil.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Models.IdentityModels.SignIn
{
    public class SignInResponseModel
    {
        public bool IsSuccess { get; set; }
        public JwtTokenDto Token { get; set; }
        public string Error { get; set; }
    }
}
