using Ardil.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Ardil.Web.ViewComponents
{
    public class PopularTopicsViewComponent: ViewComponent
    {

        private readonly IEntryService _entryService;

        public PopularTopicsViewComponent(IEntryService entryService)
        {
            _entryService = entryService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topicalEntries = await _entryService.GetTopicalEntries();
            return View(topicalEntries);
        }
    }
}
