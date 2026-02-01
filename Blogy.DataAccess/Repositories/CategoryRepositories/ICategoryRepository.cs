using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;

namespace Blogy.DataAccess.Repositories.CategoryRepositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithBlogsAsync();
        Task<int> GetCategoryCountAsync();
    }
}
