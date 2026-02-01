using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class UiLayoutController(IBlogService _blogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetLast3BlogsAsync();
            ViewBag.last3Blogs = values;
            return View();
        }
    }
}
