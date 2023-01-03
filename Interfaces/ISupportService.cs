using apisistec.Dtos;
using apisistec.Dtos.Support;
using apisistec.Entities;
using apisistec.Models.Parameters;
using apisistec.Models.Parameters.Support;

namespace apisistec.Interfaces
{
    public interface ISupportService
    {
        CredentialsToken GetUserSupportCredentials();
        string GetSuppportToken(string userId, string companyId);
        IssueCreatedResponseDto CreateSupport(IssueCreateDto create);
        PaginationDto<SupportDto> GetByUser(QueryParams qParams);
        UpdateDetailTimingDto UpdateSupportDetail(UpdateDetailTimingDto detail);
        PaginationDto<SupportDto> GetWithParams(SupportQParams qParams);
        List<IssueTimingDto> GetTiming(Guid detailId);
    }
}
