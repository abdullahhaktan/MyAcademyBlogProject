using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class MainLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
