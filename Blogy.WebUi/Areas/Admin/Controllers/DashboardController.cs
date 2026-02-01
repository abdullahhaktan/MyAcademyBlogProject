using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Services.UserServices;
using Blogy.WebUi.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")] // Restrict access to Admin role only
    public class DashboardController : Controller
    {
        // Dependency injection for dashboard statistics services
        private readonly IBlogService _blogService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public DashboardController(IBlogService blogService, ICommentService commentService, IUserService userService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _commentService = commentService;
            _userService = userService;
            _categoryService = categoryService;
        }

        // Main dashboard action displaying key statistics
        public async Task<IActionResult> Index()
        {
            // Load total counts for dashboard widgets
            ViewBag.TotalPosts = await _blogService.GetTotalBlogCount();
            ViewBag.TotalComments = await _commentService.GetTotalCommentCount();
            ViewBag.TotalUsers = await _userService.GetTotalUserCount();
            ViewBag.TotalCategory = await _categoryService.GetCategoryCountAsync();

            // Load monthly trend data for charts
            ViewBag.PostsPerMounth = await _blogService.GetMonthlyBlogCountsAsync();
            ViewBag.UsersPerMonth = await _userService.GetMonthlyUserCounts();

            return View();
        }
    }
}