using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class BlogMappings : Profile
    {
        public BlogMappings()
        {
            CreateMap<Blog, ResultBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<ResultBlogDto, UpdateBlogDto>().ReverseMap();
        }
    }
}
