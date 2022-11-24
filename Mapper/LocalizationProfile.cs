using apisistec.Dtos.Localization;
using apisistec.Entities;
using AutoMapper;

namespace apisistec.Mapper
{
    public class LocalizationProfile : Profile
    {
        public LocalizationProfile()
        {
            CreateMap<Provincias, ProvinceDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.CodigoLocalizacionProvincia))
                .ForMember(dest => dest.InecId,
                    opt => opt.MapFrom(o => o.CodigoInecLocalizacionProvincia))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(o => o.NombreLocalizacionProvincia))
                .ForMember(dest => dest.Abreviation,
                    opt => opt.MapFrom(o => o.AbreviadoLocalizacionProvincia))
                .ForMember(dest => dest.Cantons,
                    opt => opt.MapFrom(o => o.Cantones));

            CreateMap<Cantones, CantonDto>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(o => o.CodigoLocalizacionCanton))
                .ForMember(dest => dest.InecId,
                    opt => opt.MapFrom(o => o.CodigoInecLocalizacionCanton))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(o => o.NombreLocalizacionCanton))
                .ForMember(dest => dest.Abreviation,
                    opt => opt.MapFrom(o => o.AbreviadoLocalizacionCanton));
        }
    }
}
