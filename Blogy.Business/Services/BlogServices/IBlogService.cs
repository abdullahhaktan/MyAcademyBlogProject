using Blogy.Business.DTOs.BlogDtos;

namespace Blogy.Business.Services.BlogServices
{
    public interface IBlogService : IGenericService<ResultBlogDto, UpdateBlogDto, CreateBlogDto>
    {
        Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync();
        Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId);
        Task<List<ResultBlogDto>> GetLast3BlogsAsync();
        Task<List<ResultBlogDto>> GetLast5BlogsAsync();
        Task<int> GetBlogCountWithCategory(int id);
        Task<List<ResultBlogDto>> GetBlogsByWriterAsync(int writerId);
        Task<int> GetTotalBlogCount();
        Task<List<int>> GetMonthlyBlogCountsAsync();
    }
}
