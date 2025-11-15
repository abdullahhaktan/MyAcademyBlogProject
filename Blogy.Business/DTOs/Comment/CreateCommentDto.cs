using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.Comment
{
    public class CreateCommentDto
    {
        public string? Content { get; set; }

        public int? BlogId { get; set; }

        public int? UserId { get; set; }
    }
}
