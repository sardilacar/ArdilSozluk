using Ardil.Application.Abstractions.Identity;
using Ardil.Application.Abstractions.Jwt;
using Ardil.Application.DTOs;
using Ardil.Application.Exceptions.IdentityExceptions;
using Ardil.Domain.Entities.Identity;
using Ardil.Application.Models.IdentityModels.SignIn;
using Ardil.Application.Models.IdentityModels.SignUp;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardil.Persistence.Concretes.Identity
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<SignInResponseModel> SignInAsync(SignInRequestModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail.ToUpper().Normalize());
            if (user == null)
                user = await _userManager.FindByNameAsync(model.UserNameOrEmail.ToUpper().Normalize());
            if (user == null)
                throw new UserNotFoundException("Wrong Username/Email or Password");
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password.ToString(), false);
            if (result.Succeeded)
            {
                //var role = await _roleManager.FindByIdAsync(user.RoleId.ToString());
                var userRoles = await _userManager.GetRolesAsync(user);
                JwtTokenDto token = _tokenHandler.CreateAccessToken(5, user, userRoles.ToList());
               
                return new SignInResponseModel()
                {
                    IsSuccess = true,
                    Token = token,
                };
            }
            throw new UserNotFoundException("Wrong Username/Email or Password");
        }

        public async Task<SignUpResponseModel> SignUpAsync(SignUpRequestModel model)
        {
            if(model.Password == model.RepeatPassword)
            {
                var role = await _roleManager.FindByNameAsync("ÇAYLAK".Normalize());
                if (role == null)
                {
                    throw new Exception("Bir hata meydana geldi");
                }
                else
                {
                    var result = await _userManager.CreateAsync(new AppUser()
                    {
                        Id = Guid.NewGuid(),
                        UserName = model.UserName,
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        RoleId = role.Id,
                        CreatedDate = DateTime.UtcNow
                    }, model.Password);
                    if (result.Succeeded)
                    {
                        return new() { IsSuccess = true};
                    }
                    else
                    {
                        return new() { IsSuccess = false, ErrorMessages = result.Errors.ToList() };
                    }
                }
                

            }
            throw new Exception("Girdiğiniz Şifreler Eşleşmiyor");
        }
    }
}
