namespace Blogy.Business.DTOs.BlogDtos
{
    public class CreateBlogDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public string? BlogImage1 { get; set; }
        public string? BlogImage2 { get; set; }

        public int CategoryId { get; set; }
        public int WriterId { get; set; }
    }
}
