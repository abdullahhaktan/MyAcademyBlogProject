using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class Contact : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
    }
}
