using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.DTOs.Comment;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;

namespace Blogy.WebUi.Controllers
{
    public class BlogController(IBlogService _blogService, ICategoryService _categoryService , IMapper _mapper , UserManager<AppUser> _userManager) : Controller
    {
        private async Task CategoryBlogCountAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            List<CategoryWithBlogCountDto> blogsAndCounts = new List<CategoryWithBlogCountDto>();

            foreach (var category in categories)
            {
                var blogCount = await _blogService.GetBlogCountWithCategory(category.Id);

                // 4. Yeni DTO nesnesini oluştur ve listeye ekle
                blogsAndCounts.Add(new CategoryWithBlogCountDto
                {
                    CategoryId = category.Id,
                    CategoryName = category.CategoryName,
                    BlogCount = blogCount
                });
            }

            ViewBag.blogAndCounts = blogsAndCounts;
        }
        public async Task<IActionResult> Index(int page = 1 , int pageSize=2)
        {
            var blogs = await _blogService.GetAllAsync();

            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable() , page , pageSize);

            await CategoryBlogCountAsync();

            return View(values);
        }

        public async Task<IActionResult> GetBlogsByCategory(int id, int page = 1, int pageSize = 2)
        {
            var blogs = await _blogService.GetBlogsByCategoryIdAsync(id);

            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);

            await CategoryBlogCountAsync();

            var category = await _categoryService.GetByIdAsync(id);
            ViewBag.CategoryName = category.Name;

            return View(values);
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            await CategoryBlogCountAsync();

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

            ViewBag.Login = login;
            var blog = await _blogService.GetByIdAsync(id);
            var value = _mapper.Map<ResultBlogDto>(blog);
            return View(value);
        }
    }
}
