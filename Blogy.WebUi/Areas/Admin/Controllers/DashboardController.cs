using AutoMapper.Execution;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Services.UserServices;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public DashboardController(IBlogService blogService, ICommentService commentService, IUserService userService , ICategoryService categoryService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _userService = userService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TotalPosts = await _blogService.GetTotalBlogCount();
            ViewBag.TotalComments = await _commentService.GetTotalCommentCount();
            ViewBag.TotalUsers = await _userService.GetTotalUserCount();
            ViewBag.TotalCategory = await _categoryService.GetCategoryCountAsync();

            ViewBag.PostsPerMounth = await _blogService.GetMonthlyBlogCountsAsync();
            ViewBag.UsersPerMonth = await _userService.GetMonthlyUserCounts();

            return View();
        }
    }
}
