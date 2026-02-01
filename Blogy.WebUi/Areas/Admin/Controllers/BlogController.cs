using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.OpenAIService;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")] // Restrict to Admin role only
    public class BlogController : Controller
    {
        // Dependency injection for required services
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

        // Helper method to load categories for dropdown selection
        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.categories = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            }).ToList();
        }

        // Display list of all blogs
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        // Display form to create new blog
        public async Task<IActionResult> CreateBlog()
        {
            await GetCategoriesAsync(); // Load categories for dropdown
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto blogDto)
        {
            // Validate model before processing
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(blogDto);
            }

            // Get current user and assign as writer
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            blogDto.WriterId = user.Id;

            await _blogService.CreateAsync(blogDto);
            return RedirectToAction(nameof(Index));
        }

        // API endpoint to generate article using OpenAI
        [HttpGet]
        public async Task<IActionResult> GenerateArticle(string shortDescription, string keywords)
        {
            // Validate input parameters
            if (string.IsNullOrWhiteSpace(shortDescription) || string.IsNullOrWhiteSpace(keywords))
            {
                return Json(new { success = false, message = "Kısa açıklama veya anahtar kelimeler boş olamaz" });
            }

            // Convert comma-separated keywords to list
            var keywordList = keywords.Split(',', System.StringSplitOptions.RemoveEmptyEntries | System.StringSplitOptions.TrimEntries).ToList();

            // Call OpenAI service to generate article
            var article = await _openAiService.GenerateArticleAsync(shortDescription, keywordList);

            if (string.IsNullOrWhiteSpace(article))
            {
                return Json(new { success = false, message = "Makale oluşturulamadı. Daha sonra tekrar deneyin." });
            }

            return Json(new { success = true, article });
        }
    }
}