using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.Common;
using Blogy.Business.DTOs.UserDtos;

namespace Blogy.Business.DTOs.Comment
{
    public class ResultCommentDto : BaseDto
    {
        public string? Content { get; set; }

        public int BlogId { get; set; }
        public ResultBlogDto Blog { get; set; }

        public int UserId { get; set; }
        public ResultUserDto User { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
