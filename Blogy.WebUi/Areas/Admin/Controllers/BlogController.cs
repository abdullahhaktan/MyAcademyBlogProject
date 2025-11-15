using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blogy.Business.Services.OpenAIService;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOpenAIService _openAiService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, UserManager<AppUser> userManager, IOpenAIService openAIService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userManager = userManager;
            _openAiService = openAIService;
        }

        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.categories = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        public async Task<IActionResult> CreateBlog()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(blogDto);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            blogDto.WriterId = user.Id;
            await _blogService.CreateAsync(blogDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateArticle(string shortDescription, string keywords)
        {
            if (string.IsNullOrWhiteSpace(shortDescription) || string.IsNullOrWhiteSpace(keywords))
            {
                return Json(new { success = false, message = "Kısa açıklama veya anahtar kelimeler boş olamaz" });
            }

            var keywordList = keywords.Split(',', System.StringSplitOptions.RemoveEmptyEntries | System.StringSplitOptions.TrimEntries).ToList();
            var article = await _openAiService.GenerateArticleAsync(shortDescription, keywordList);

            if (string.IsNullOrWhiteSpace(article))
            {
                return Json(new { success = false, message = "Makale oluşturulamadı. Daha sonra tekrar deneyin." });
            }

            return Json(new { success = true, article });
        }
    }
}
