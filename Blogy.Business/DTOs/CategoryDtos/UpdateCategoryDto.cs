using Blogy.Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.CategoryDtos
{
    public class UpdateCategoryDto:BaseDto
    {
        public string Name { get; set; }
    }
}
