using Blogy.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Entity.Entities
{
    public class Contact:BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
    }
}
