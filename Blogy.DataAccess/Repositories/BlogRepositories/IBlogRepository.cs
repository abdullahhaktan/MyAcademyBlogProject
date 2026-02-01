using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;

namespace Blogy.DataAccess.Repositories.BlogRepositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<List<Blog>> GetBlogsWithCategories();
        Task<int> GetBlogCountByCategory(int id);
        Task<List<Blog>> GetLast3BlogsAsync();
        Task<List<Blog>> GetLast5BlogsAsync();
        Task<List<Blog>> GetBlogsByWriterAsync(int id);
        Task<int> GetTotalBlogCountAsync();
        Task<List<int>> GetMonthlyBlogCountsAsync();
    }
}
