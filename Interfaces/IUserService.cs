using apisistec.Dtos;
using apisistec.Dtos.Users;
using apisistec.Entities;

namespace apisistec.Interfaces
{
    public interface IUserService
    {
        Users? FindUserByEmail(string email);
        Users? FindUserById(string ID);
        Users Register(UserRegisterDto userRegisterDto);
        string GetToken(Guid id, string Email);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
        Users UpdateInfo(Users user, UpdateClienteDto userUpdate);
        UserDto WhoIAm(string userId);
        string? GetUserLoggedId();
        UserDto UpdatePassword(UpdatePasswordDto data, Users user);
        string RamdomPassword();
    }
}
