using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.Entity.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.BlogServices
{
    public class BlogService(IBlogRepository _blogRepository ,  IMapper _mapper) : IBlogService
    {
        public async Task CreateAsync(CreateBlogDto dto)
        {
            var entity = _mapper.Map<Blog>(dto);
            await _blogRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
           await _blogRepository.DeleteAsync(id);
        }

        public async Task<List<ResultBlogDto>> GetAllAsync()
        {
            var values = await _blogRepository.GetAllAsync();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task<List<ResultBlogDto>> GetBlogsByWriterAsync(int writerId)
        {
            var value = await _blogRepository.GetBlogsByWriterAsync(writerId);
            return _mapper.Map<List<ResultBlogDto>>(value);
        }

        public async Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            var values = await _blogRepository.GetAllAsync(x => x.CategoryId == categoryId);

            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync()
        {
            var values = await _blogRepository.GetBlogsWithCategories();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task<UpdateBlogDto> GetByIdAsync(int id)
        {
            var value = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateBlogDto>(value);
        }

        public async Task<List<ResultBlogDto>> GetLast3BlogsAsync()
        {
            var values = await _blogRepository.GetLast3BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task UpdateAsync(UpdateBlogDto updateBlogDto)
        {
            var entity =  _mapper.Map<Blog>(updateBlogDto);
            await _blogRepository.UpdateAsync(entity);
        }

        public async Task<List<ResultBlogDto>> GetLast5BlogsAsync()
        {
            var values = await _blogRepository.GetLast5BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task<int> GetBlogCountWithCategory(int id)
        {
            var count = await _blogRepository.GetBlogCountByCategory(id);
            return count;
        }

        public async Task<int> GetTotalBlogCount()
        {
            return await _blogRepository.GetTotalBlogCountAsync();
        }

        public async Task<List<int>> GetMonthlyBlogCountsAsync()
        {
            return await _blogRepository.GetMonthlyBlogCountsAsync();
        }
    }
}
