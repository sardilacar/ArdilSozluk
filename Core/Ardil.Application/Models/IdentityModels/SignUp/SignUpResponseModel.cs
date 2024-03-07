using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Models.IdentityModels.SignUp
{
    public class SignUpResponseModel
    {
        public bool IsSuccess { get; set; }
        public List<IdentityError>? ErrorMessages { get; set; }
    }
}
