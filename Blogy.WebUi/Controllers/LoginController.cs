using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class LoginController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                return View(loginDto);
            }

            ViewBag.role = "Admin";
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriterLogin(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                return View("WriterLogin", loginDto);
            }

            ViewBag.role = "Writer";
            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                return View("UserLogin", loginDto);
            }

            ViewBag.role = "User";
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
