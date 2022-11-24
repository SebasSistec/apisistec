using apisistec.Entities;

namespace apisistec.Interfaces
{
    public interface IRestorePasswordService
    {
        RestorePassword RestorePassword(string email);
        RestorePassword? VerifyId(Guid id);
        Users UpdatePassword(Users user, string password);
    }
}
