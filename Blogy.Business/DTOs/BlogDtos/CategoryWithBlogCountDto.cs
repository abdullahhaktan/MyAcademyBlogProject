namespace Blogy.Business.DTOs.BlogDtos
{
    public class CategoryWithBlogCountDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BlogCount { get; set; }
    }
}
