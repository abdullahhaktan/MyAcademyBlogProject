using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Authorize]
    [Area(Roles.Admin)]
    public class ChangePasswordController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ChangePasswordDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return View(model);
            }

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "ChangePassword", new { area = Roles.Admin });
        }
    }
}