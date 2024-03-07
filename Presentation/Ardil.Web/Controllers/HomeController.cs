using Ardil.Application.Abstractions;
using Ardil.Domain.Enums.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ardil.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IEntryService _entryService;

        public HomeController(IEntryService entryService)
        {
            _entryService = entryService;
        }



        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string topicId)
        {
            if(topicId == null)
            {
                return View();
            }
            var entries = await _entryService.GetEntriesByTopicId(topicId);
            return View(entries);
        }
    }
}