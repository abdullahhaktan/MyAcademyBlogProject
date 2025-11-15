using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class DefaultController(IBlogService _blogService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var last5Blog = await _blogService.GetLast5BlogsAsync();
            ViewBag.Last5Blog = last5Blog;
            return View(last5Blog);
        }
    }
}