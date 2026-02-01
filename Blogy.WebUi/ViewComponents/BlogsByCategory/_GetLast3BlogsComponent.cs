using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.ViewComponents.BlogsByCategory
{
    public class _GetLast3BlogsComponent(IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _blogService.GetLast3BlogsAsync();
            ViewBag.last3Blogs = values;

            return View();
        }
    }
}
