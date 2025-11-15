using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Threading.Tasks;

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
