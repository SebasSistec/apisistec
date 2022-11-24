using apisistec.Dtos.Support;

namespace apisistec.Interfaces
{
    public interface ISupportService
    {
        CredentialsToken GetUserSupportCredentials();
        string GetSuppportToken(string userId, string companyId);
        IssueCreatedResponseDto CreateSupport(IssueCreateDto create);
    }
}
