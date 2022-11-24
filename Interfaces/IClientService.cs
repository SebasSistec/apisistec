using apisistec.Dtos;
using apisistec.Dtos.Billing;
using apisistec.Dtos.Client;
using apisistec.Entities;
using apisistec.Models.Parameters;

namespace apisistec.Interfaces
{
    public interface IClientService
    {
        Cliente? FindByIdentification(string identification);
        Cliente Create(CustomerDto customer);
        PaginationDto<ClientDto> Find(QueryStringParams qParams);
    }
}
