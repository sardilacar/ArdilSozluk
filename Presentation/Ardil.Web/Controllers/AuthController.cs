using Ardil.Application.Abstractions.Identity;
using Ardil.Application.Exceptions.IdentityExceptions;
using Ardil.Application.Helper.BaseClasses;
using Ardil.Domain.Entities.Identity;
using Ardil.Application.Models.IdentityModels.SignIn;
using Ardil.Application.Models.IdentityModels.SignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Ardil.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInRequestModel model)
        {
            try{
                var result = await _authService.SignInAsync(model);
                if (result.IsSuccess)
                {
                    HttpContext.Session.SetString("X-Access-Token", result.Token.AccessToken);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Error);
                }
            }
            catch (UserNotFoundException e){
                ModelState.AddModelError("UserNotFoundError", e.Message);
                return View(model);
            }
            return RedirectToAction("Index","Home");
        }
        [AllowAnonymous]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("X-Access-Token");
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);

            return RedirectToAction("SignIn", "Auth");
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpRequestModel model)
        {
            try
            {
                var result = await _authService.SignUpAsync(model);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.ErrorMessages)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch (UserNotFoundException e)
            {
                ModelState.AddModelError("UserNotFoundError", e.Message);
            }
            return View(model);
        }
    }
}
