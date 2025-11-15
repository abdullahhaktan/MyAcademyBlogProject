using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.CategoryDtos
{
    public class ResultCategoryDto:BaseDto
    {
        public string? CategoryName { get; set; }

        public IList<ResultBlogDto> Blogs { get; set; }
    }
}
