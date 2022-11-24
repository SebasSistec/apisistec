using apisistec.Mapper;
using AutoMapper;

namespace apisistec.Models
{
    public class AutomapperProfiles
    {
        public static Action<IMapperConfigurationExpression> ProfilesConfig =
              new(cfg =>
              {
                  //add mappers
                  cfg.AddProfile<UsersProfile>();
              });
    }
}
