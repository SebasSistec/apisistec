using apisistec.Dtos;
using apisistec.Dtos.Support;
using apisistec.Entities;
using apisistec.Models.Parameters;

namespace apisistec.Interfaces
{
    public interface ISupportService
    {
        CredentialsToken GetUserSupportCredentials();
        string GetSuppportToken(string userId, string companyId);
        IssueCreatedResponseDto CreateSupport(IssueCreateDto create);
        PaginationDto<SupportDto> GetByUser(QueryParams qParams);
        UpdateDetailTimingDto UpdateSupportDetail(UpdateDetailTimingDto detail);
    }
}
