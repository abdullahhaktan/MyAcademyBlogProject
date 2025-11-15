using Blogy.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class BlogTag:BaseEntity
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
