using AutoMapper;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class CategoryMappings:Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, ResultCategoryDto>()
                .ForMember(dst => dst.CategoryName,
                o => o.MapFrom(src => src.Name));

            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
        }
    }
}
