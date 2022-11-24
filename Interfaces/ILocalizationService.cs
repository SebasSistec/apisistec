using apisistec.Dtos.Localization;
using apisistec.Entities;

namespace apisistec.Interfaces
{
    public interface ILocalizationService
    {
        List<ProvinceDto> ProvincesWithCantons();
    }
}
