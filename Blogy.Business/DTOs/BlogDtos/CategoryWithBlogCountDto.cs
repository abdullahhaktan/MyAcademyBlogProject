using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.BlogDtos
{
    public class CategoryWithBlogCountDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
