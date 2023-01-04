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
                  cfg.AddProfile<BillingProfile>();
                  cfg.AddProfile<ClientProfile>();
                  cfg.AddProfile<ContractsPlansProfile>();
                  cfg.AddProfile<EmployeeProfile>();
                  cfg.AddProfile<LocalizationProfile>();
                  cfg.AddProfile<PlanProfile>();
                  cfg.AddProfile<ProductProfile>();
                  cfg.AddProfile<SupportProfile>();
              });
    }
}
