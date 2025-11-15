using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.DTOs.Comment;
using Blogy.Business.DTOs.Common;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.BlogDtos
{
    public class ResultBlogDto:BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string BlogImage1 { get; set; }
        public string BlogImage2 { get; set; }
        public int CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<BlogTag> BlogTags { get; set; }
        public int WriterId { get; set; }
        public ResultUserDto? Writer { get; set; } 
        public IList<ResultCommentDto> Comments {  get; set; }

    }
}
