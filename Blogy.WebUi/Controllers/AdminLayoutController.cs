using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
