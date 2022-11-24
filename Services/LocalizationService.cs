using apisistec.Context;
using apisistec.Dtos.Localization;
using apisistec.Entities;
using apisistec.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace apisistec.Services
{
    public class LocalizationService : ILocalizationService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public LocalizationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ProvinceDto> ProvincesWithCantons()
        {
            List<Provincias> provinces = _context.Provinces
                .Include(x => x.Cantones)
                .OrderBy(x => x.NombreLocalizacionProvincia)
                .ToList();

            return _mapper.Map<List<ProvinceDto>>(provinces);
        }
    }
}
