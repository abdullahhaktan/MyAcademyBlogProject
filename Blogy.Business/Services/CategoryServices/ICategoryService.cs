using Blogy.Business.DTOs.CategoryDtos;

namespace Blogy.Business.Services.CategoryServices
{
    public interface ICategoryService : IGenericService<ResultCategoryDto, UpdateCategoryDto, CreateCategoryDto>
    {
        Task<List<ResultCategoryDto>> GetCategoriesWithBlogsAsync();
        Task<int> GetCategoryCountAsync();
    }
}
