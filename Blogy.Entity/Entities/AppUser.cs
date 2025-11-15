using Blogy.Entity.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }

        public virtual IList<Blog> Blogs { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
