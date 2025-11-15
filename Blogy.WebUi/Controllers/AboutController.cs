using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
