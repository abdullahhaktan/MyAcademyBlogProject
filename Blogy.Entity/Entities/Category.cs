using Blogy.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Blog> Blogs { get; set; }
    }
}
