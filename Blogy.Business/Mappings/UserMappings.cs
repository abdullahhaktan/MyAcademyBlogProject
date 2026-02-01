using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<AppUser, ResultUserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => string.Join(" ", src.FirstName, src.LastName)));

            CreateMap<AppUser, EditProfileDto>().ReverseMap();
        }
    }
}
