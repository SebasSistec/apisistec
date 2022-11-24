namespace apisistec.Dtos.Localization
{
    public class ProvinceDto : CantonDto
    {
        public List<CantonDto> Cantons { get; set; } = new();
    }
}
