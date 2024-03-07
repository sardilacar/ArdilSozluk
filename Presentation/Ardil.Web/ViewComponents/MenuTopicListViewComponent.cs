using Microsoft.AspNetCore.Mvc;

namespace Ardil.Web.ViewComponents
{
    public class MenuTopicListViewComponent: ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
