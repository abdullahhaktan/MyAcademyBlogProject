using Blogy.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<BlogTag> BlogTags { get; set; }
    }
}