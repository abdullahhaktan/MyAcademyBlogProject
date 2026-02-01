using AutoMapper;
using Blogy.Business.DTOs.Comment;
using Blogy.DataAccess.Repositories.CommentRepositories;
using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Services.CommentServices
{
    public class CommentService(ICommentRepository _commentRepository, IMapper _mapper, IValidator<Comment> _validator) : ICommentService
    {
        public async Task CreateAsync(CreateCommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            var result = await _validator.ValidateAsync(comment);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _commentRepository.CreateAsync(comment);
        }

        public async Task DeleteAsync(int id)
        {
            await _commentRepository.DeleteAsync(id);
        }

        public async Task<List<ResultCommentDto>> GetAllAsync()
        {
            var values = await _commentRepository.GetAllAsync();
            return _mapper.Map<List<ResultCommentDto>>(values);
        }

        public async Task<UpdateCommentDto> GetByIdAsync(int id)
        {
            var value = await _commentRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCommentDto>(value);
        }

        public async Task<int> GetTotalCommentCount()
        {
            return await _commentRepository.GetTotalCommentAsync();
        }

        public async Task UpdateAsync(UpdateCommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            var result = await _validator.ValidateAsync(comment);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            await _commentRepository.UpdateAsync(comment);
        }
    }
}
