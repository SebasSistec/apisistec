using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Users;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Interfaces;
using apisistec.Models.Common;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace apisistec.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccesor;

        public UserService(
            IOptions<AppSettings> appSettings,
            DataContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccesor)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _mapper = mapper;
            _httpContextAccesor = httpContextAccesor;
        }

        public Users? FindUserByEmail(string email)
        {
            Users? user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
        public Users? FindUserById(string ID)
        {
            Users? user = _context.Users.FirstOrDefault(x => x.Id.ToString() == ID);
            return user;
        }

        public string GetToken(Guid id, string email)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                            new Claim[]
                            {
                                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                                new Claim(ClaimTypes.Email, email)
                            }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                                SecurityAlgorithms.HmacSha256Signature
                                                            )
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public Users Register(UserRegisterDto userRegisterDto)
        {
            Users user = _mapper.Map<Users>(userRegisterDto);
            CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }
        public Users UpdateInfo(Users user, UpdateClienteDto userUpdate)
        {
            user.FirstName = seletecAtribute(user.FirstName, userUpdate.FirstName);
            user.LastName = seletecAtribute(user.LastName, userUpdate.LastName);
            user.Phone = seletecAtribute(user.Phone, userUpdate.Phone);
            if (!user.Email.Equals(userUpdate.Email))
            {
                user.Email = userUpdate.Email;
                user.EmailVerified = StateEnum.DISABLED;
            }
            return user;
        }

        private string seletecAtribute(string oldAttribute, string newAttribute)
        {
            return string.IsNullOrEmpty(newAttribute) ? oldAttribute : newAttribute;
        }

        public UserDto WhoIAm(string userId)
        {
            Users? user = _context.Users.Where(x => x.Id.ToString().Equals(userId)).FirstOrDefault();
            UserDto userReturn = _mapper.Map<UserDto>(user);
            return userReturn;
        }

        public UserDto UpdatePassword(UpdatePasswordDto data, Users user)
        {
            CreatePasswordHash(data.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            UserDto userDto = _mapper.Map<UserDto>(user);
            _context.Users.Update(user);
            return userDto;
        }

        public string? GetUserLoggedId()
        {
            string Id = _httpContextAccesor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid result;
            if (Guid.TryParse(Id, out result))
                return result.ToString();
            return null;
        }

        public string RamdomPassword()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 6;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }
    }
}
