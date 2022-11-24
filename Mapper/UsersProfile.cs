using apisistec.Dtos;
using apisistec.Dtos.Users;
using apisistec.Entities;
using apisistec.Enums;
using AutoMapper;

namespace apisistec.Mapper
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UserDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(o => o.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(o => o.LastName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(o => o.Email))
                .ForMember(dest => dest.Phone,
                    opt => opt.MapFrom(o => o.Phone));

            CreateMap<UserRegisterDto, Users>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(o => o.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(o => o.LastName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(o => o.Email))
                .ForMember(dest => dest.State,
                    opt => opt.MapFrom(o => StateEnum.ENABLED))
                .ForMember(dest => dest.EmailVerified,
                    opt => opt.MapFrom(o => o.State ?? StateEnum.DISABLED))
                .ForMember(dest => dest.Phone,
                    opt => opt.MapFrom(o => o.Phone))
                .ForMember(dest => dest.RegistrationDate,
                    opt => opt.MapFrom(o => DateTime.Now));

            CreateMap<Users, UserLoggedDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(o => o.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(o => o.LastName))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(o => o.Email))
                .ForMember(dest => dest.Phone,
                    opt => opt.MapFrom(o => o.Phone));
        }
    }
}
