using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class RegisterController(UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {

            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerDto);
            }

            var user1 = await _userManager.FindByNameAsync(registerDto.UserName);

            // Kayıt olan her kişiye otomatik User rolü atama olayı
            await _userManager.AddToRoleAsync(user1, "User");

            return RedirectToAction("UserLogin", "Login");
        }
    }
}
