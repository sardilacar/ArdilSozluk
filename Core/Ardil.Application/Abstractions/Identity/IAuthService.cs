using Ardil.Application.Models.IdentityModels.SignIn;
using Ardil.Application.Models.IdentityModels.SignUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Application.Abstractions.Identity
{
    public interface IAuthService
    {
        public Task<SignInResponseModel> SignInAsync(SignInRequestModel model);
        public Task<SignUpResponseModel> SignUpAsync(SignUpRequestModel model);
    }
}
