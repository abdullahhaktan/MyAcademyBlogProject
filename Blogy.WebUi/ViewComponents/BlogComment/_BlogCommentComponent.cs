using Blogy.Business.DTOs.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.ViewComponents.BlogComment
{
    public class _BlogCommentComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            CreateCommentDto createCommentDto = new CreateCommentDto();
            return View(createCommentDto);
        }
    }
}
