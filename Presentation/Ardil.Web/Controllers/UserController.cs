using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ardil.Web.Controllers
{
    [Authorize(Roles = "Admin,Çaylak,Yazar")]
    public class UserController : Controller
    {
        [HttpGet("/{userName}")]
        public IActionResult Index(string userName)
        {
            return View();
        }
    }
}
