using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.ViewComponents.BlogsByCategory
{
    public class _BlogsByCategoryLatestBlogsComponent(IBlogService _blogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _blogService.GetLast3BlogsAsync();
            return View(blogs);
        }
    }
}
