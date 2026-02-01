namespace Blogy.Business.Services.OpenAIService
{
    public interface IOpenAIService
    {
        Task<string?> GenerateArticleAsync(string shortDescription, List<string> keywords);

        Task<string> ContactResponse(string request);
    }
}
