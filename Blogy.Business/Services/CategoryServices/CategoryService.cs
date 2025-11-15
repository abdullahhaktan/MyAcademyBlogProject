using AutoMapper;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.CategoryServices
{
    public class CategoryService(ICategoryRepository _categoryRepository, IMapper _mapper) : ICategoryService
    {

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCategoryDto>(category);
        }

        public async Task<List<ResultCategoryDto>> GetCategoriesWithBlogsAsync()
        {
            var categories = await _categoryRepository.GetCategoriesWithBlogsAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<int> GetCategoryCountAsync()
        {
            var count = await _categoryRepository.GetCategoryCountAsync();
            return count;
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
