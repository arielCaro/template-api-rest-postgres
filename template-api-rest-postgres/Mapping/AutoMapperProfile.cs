using AutoMapper;
using template.api.postgres.data.Models;
using template_api_rest_postgres.Dto;

namespace template_api_rest_postgres.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, TbUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.IdCompany, opt => opt.MapFrom(src => src.IdCompany))
                .ForMember(dest => dest.UserCreated, opt => opt.MapFrom(src => src.UserCreated))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.UserModified, opt => opt.MapFrom(src => src.UserModified))
                .ForMember(dest => dest.DateModified, opt => opt.MapFrom(src => src.DateModified));
        }
    }
}
