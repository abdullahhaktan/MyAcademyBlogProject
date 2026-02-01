using Blogy.Business.Services.ContactServices;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class ContactController(IContactService _contactService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllAsync();
            return View(values);
        }
    }
}
