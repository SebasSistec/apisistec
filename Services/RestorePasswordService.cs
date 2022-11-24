using apisistec.Context;
using apisistec.Entities;
using apisistec.Interfaces;
using AutoMapper;

namespace apisistec.Services
{
    public class RestorePasswordService : IRestorePasswordService
    {
        private DataContext _context;
        private IUserService _userService;
        private IMapper _mapper;

        public RestorePasswordService(
                    DataContext context,
                    IUserService userService,
                    IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        public RestorePassword RestorePassword(string email)
        {
            RestorePassword? verify = _context.RestorePassword.FirstOrDefault(x => x.Email == email);
            if (verify != null)
                _context.RestorePassword.Remove(verify);

            return new RestorePassword
            {
                Id = Guid.NewGuid(),
                Email = email,
            };
        }

        public Users UpdatePassword(Users user, string password)
        {
            _userService.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return user;
        }

        public RestorePassword? VerifyId(Guid id)
        {
            RestorePassword? restoreId = _context
                                            .RestorePassword
                                                .FirstOrDefault(x => x.Id == id);
            return restoreId;
        }
    }
}
