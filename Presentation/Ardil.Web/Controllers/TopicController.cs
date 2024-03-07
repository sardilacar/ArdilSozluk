using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ardil.Web.Controllers
{
    [Authorize(Roles = "Admin,Yazar")]
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
