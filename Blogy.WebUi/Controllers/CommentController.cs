using AutoMapper;
using Blogy.Business.DTOs.Comment;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Services.HuggingFaceService;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUi.Controllers
{
    public class CommentController(
        IMapper _mapper,
        ICommentService _commentService,
        UserManager<AppUser> _userManager, IHuggingFaceService
         _huggingFaceService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto, int BlogId)
        {
            if (string.IsNullOrWhiteSpace(createCommentDto.Content))
            {
                TempData["ErrorMessage"] = "Yorum içeriği boş olamaz.";
                return RedirectToAction("BlogDetails", "Blog", new { id = BlogId });
            }

            string? translatedText = await _huggingFaceService.TranslateTextToEnglish(createCommentDto.Content);
            if (string.IsNullOrEmpty(translatedText))
            {
                TempData["ErrorMessage"] = "Yorum çeviri servisine ulaşılamadı. Lütfen daha sonra tekrar deneyin.";
                return RedirectToAction("BlogDetails", "Blog", new { id = BlogId });
            }

            bool toxicScore = await _huggingFaceService.IsCommentToxic(translatedText);
            const double ToxicThreshold = 0.5;
            if (toxicScore == true)
            {
                TempData["ErrorMessage"] = $"Yorumunuz yüksek oranda toksik içerik  barındırdığı için yayınlanmadı. Lütfen içeriği düzenleyin.";
                return RedirectToAction("BlogDetails", "Blog", new { id = BlogId });
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createCommentDto.UserId = user.Id;

            await _commentService.CreateAsync(createCommentDto);
            TempData["SuccessMessage"] = "Yorumunuz başarıyla yayınlandı.";

            return RedirectToAction("BlogDetails", "Blog", new { id = BlogId });
        }
    }
}
