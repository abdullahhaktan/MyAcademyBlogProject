using Blogy.Business.DTOs.Common;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.ContactDtos
{
    public class UpdateContactDto:BaseDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }

        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
