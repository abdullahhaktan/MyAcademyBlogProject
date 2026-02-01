using Blogy.Business.DTOs.Comment;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area(Roles.Admin)]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class CommentController(ICommentService _commentService, IBlogService _blogService, UserManager<AppUser> _userManager) : Controller
    {
        private async Task GetBlogs()
        {
            var blogs = await _blogService.GetAllAsync();
            ViewBag.Blogs = (from blog in blogs
                             select new SelectListItem
                             {
                                 Text = blog.Title,
                                 Value = blog.Id.ToString()
                             }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAllAsync();
            return View(comments);
        }

        public async Task<IActionResult> CreateComment()
        {
            await GetBlogs();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            await GetBlogs();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCommentDto.UserId = user.Id;

            await _commentService.CreateAsync(createCommentDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
