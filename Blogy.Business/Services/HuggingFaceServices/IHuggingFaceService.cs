namespace Blogy.Business.Services.HuggingFaceService
{
    public interface IHuggingFaceService
    {
        Task<string?> TranslateTextToEnglish(string text);
        Task<bool> IsCommentToxic(string text);
        Task<string?> ProcessComment(string text);
    }
}
