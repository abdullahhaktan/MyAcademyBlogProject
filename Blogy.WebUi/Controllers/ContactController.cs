using Blogy.Business.DTOs.ContactDtos;
using Blogy.Business.Services.ContactServices;
using Blogy.Business.Services.OpenAIService;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class ContactController(IContactService _contactService, IOpenAIService _openAiService) : Controller
    {
        public IActionResult Index()
        {
            if (TempData["MessageSend"] != null && (bool)TempData["MessageSend"])
            {
                ViewBag.message = true;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            await _contactService.CreateAsync(createContactDto);
            TempData["MessageSend"] = true;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> GetResponse(string Content)
        {

            if (string.IsNullOrEmpty(Content))
            {
                TempData["Response"] = "Lütfen istek giriniz";
            }

            TempData["Response"] = await _openAiService.ContactResponse(Content);

            return RedirectToAction("Index");
        }

    }
}
