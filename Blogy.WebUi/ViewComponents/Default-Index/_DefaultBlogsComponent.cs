using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.ViewComponents.Default_Index
{
    public class _DefaultBlogsComponent(ICategoryService _categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesWithBlogs = await _categoryService.GetCategoriesWithBlogsAsync();
            return View(categoriesWithBlogs);
        }
    }
}
