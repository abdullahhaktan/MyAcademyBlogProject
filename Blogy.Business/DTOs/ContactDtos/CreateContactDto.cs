namespace Blogy.Business.DTOs.ContactDtos
{
    public class CreateContactDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }

        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
