using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class Social : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
