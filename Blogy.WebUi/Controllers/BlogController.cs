using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blogy.WebUi.Controllers
{
    public class BlogController(IBlogService _blogService, ICategoryService _categoryService, IMapper _mapper, UserManager<AppUser> _userManager) : Controller
    {
        // Helper method to calculate blog count per category
        private async Task CategoryBlogCountAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            List<CategoryWithBlogCountDto> blogsAndCounts = new List<CategoryWithBlogCountDto>();

            foreach (var category in categories)
            {
                // Get count of blogs for each category
                var blogCount = await _blogService.GetBlogCountWithCategory(category.Id);

                // Create DTO with category info and blog count
                blogsAndCounts.Add(new CategoryWithBlogCountDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName,
                    BlogCount = blogCount
                });
            }

            // Store results in ViewBag for sidebar or menu display
            ViewBag.blogAndCounts = blogsAndCounts;
        }

        // Main blog listing with pagination
        public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
        {
            var blogs = await _blogService.GetAllAsync();

            // Create paginated list of blog DTOs
            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);

            await CategoryBlogCountAsync(); // Load category counts for sidebar

            return View(values);
        }

        // Filter blogs by specific category with pagination
        public async Task<IActionResult> GetBlogsByCategory(int id, int page = 1, int pageSize = 2)
        {
            // Get blogs filtered by category ID
            var blogs = await _blogService.GetBlogsByCategoryIdAsync(id);

            // Create paginated list
            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);

            await CategoryBlogCountAsync(); // Load category counts for sidebar

            // Get category name for display in view
            var category = await _categoryService.GetByIdAsync(id);
            ViewBag.CategoryName = category.Name;

            return View(values);
        }

        // Display single blog post with details
        public async Task<IActionResult> BlogDetails(int id)
        {
            await CategoryBlogCountAsync(); // Load category counts for sidebar

            // Check if user is authenticated
            bool login = false;
            var user = (User.Identity.Name);

            if (user == null)
            {
                login = false;
            }
            else
            {
                login = true;
            }

            ViewBag.Login = login; // Pass login status to view for UI adjustments

            // Get blog by ID and map to DTO
            var blog = await _blogService.GetByIdAsync(id);
            var value = _mapper.Map<ResultBlogDto>(blog);

            return View(value);
        }
    }
}