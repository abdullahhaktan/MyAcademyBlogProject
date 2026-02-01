using Blogy.Entity.Entities.Common;

namespace Blogy.Entity.Entities
{
    public class BlogTag : BaseEntity
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
