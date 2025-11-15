using Blogy.Business.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.CategoryServices
{
    public interface ICategoryService:IGenericService<ResultCategoryDto,UpdateCategoryDto,CreateCategoryDto>
    {
        Task<List<ResultCategoryDto>> GetCategoriesWithBlogsAsync();
        Task<int> GetCategoryCountAsync();
    }
}
