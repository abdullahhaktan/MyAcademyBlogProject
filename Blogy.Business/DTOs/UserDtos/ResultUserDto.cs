namespace Blogy.Business.DTOs.UserDtos
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public IList<string> Roles { get; set; }
    }
}
