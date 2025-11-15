using Blogy.Business.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.CommentServices
{
    public interface ICommentService:IGenericService<ResultCommentDto,UpdateCommentDto,CreateCommentDto>
    {
        Task<int> GetTotalCommentCount();
    }
}
