using Blogy.Business.DTOs.Comment;

namespace Blogy.Business.Services.CommentServices
{
    public interface ICommentService : IGenericService<ResultCommentDto, UpdateCommentDto, CreateCommentDto>
    {
        Task<int> GetTotalCommentCount();
    }
}
