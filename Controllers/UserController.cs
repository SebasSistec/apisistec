using apisistec.Context;
using apisistec.Dtos;
using apisistec.Dtos.Billing;
using apisistec.Dtos.Plans;
using apisistec.Dtos.Users;
using apisistec.Entities;
using apisistec.Enums;
using apisistec.Helpers;
using apisistec.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apisistec.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IRestorePasswordService _passwordService;
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMailingService _mailingService;
        DefaultResponses response = new();
        public UserController(
            IUserService userService,
            IRestorePasswordService passwordService,
            DataContext context,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IMailingService mailingService)
        {
            _userService = userService;
            _context = context;
            _mapper = mapper;
            _passwordService = passwordService;
            _httpContext = httpContext;
            _mailingService = mailingService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto user)
        {
            try
            {

                bool findUser = _userService.FindUserByEmail(user.Email) != null;
                if (findUser)
                    return BadRequest(response.ErrorResponse($"Ya existe una cuenta con ese correo electrónico, intente de nuevo", user));
                Users userRegister = _userService.Register(user);
                UserDto userResponse = _mapper.Map<UserDto>(userRegister);
                _context.Users.Add(userRegister);
                _context.SaveChanges();
                _mailingService.sendMail(user.Email,
                                         new
                                         {
                                             nameUser = $"{user.FirstName} {user.LastName}",
                                             urlverificador = urlBaseSendEmail(user.Email),
                                             emailUser = user.Email
                                         },
                                              TypesMail.CREATE_USER);
                return Ok(response.SuccessResponse("Usuario registrado, revise su bandeja de entrada para activar su cuenta", userResponse));
            }
            catch (Exception ex)
            {
                return BadRequest(response.ErrorResponse($"{ex.Message}", user));
            }
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthRequestDto auth)
        {
            Users? user = _userService.FindUserByEmail(auth.Email);
            if (user == null)
                return BadRequest(response.ErrorResponse($"Usuario no encontrado {auth.Email}", auth));

            if (!_userService.VerifyPassword(auth.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest(response.ErrorResponse($"Contraseña incorrecta", auth));

            if (user.State == StateEnum.DISABLED)
                return BadRequest(response.ErrorResponse($"Usuario inhabilitado {auth.Email}", auth));

            if (user.EmailVerified == StateEnum.DISABLED)
                return BadRequest(response.ErrorResponse($"Necesita activar su cuenta, revise su email por favor", auth));

            UserLoggedDto userLogged = _mapper.Map<UserLoggedDto>(user);
            userLogged.Token = _userService.GetToken(user.Id, user.Email);
            return Ok(response.SuccessResponse("Inicio de sesión exitoso, bienvenido", userLogged));
        }


        [HttpPost("authenticate-plan-wise")]
        public IActionResult AuthenticatePlanWise([FromBody] AuthRequestDto auth)
        {
            Users? user = _context.Users.Where(x => x.PasswordTemp == auth.Password &&
                                                    x.Email == auth.Email &&
                                                    x.PasswordTemp.Length > 0).FirstOrDefault();
            if (user is null)
                return BadRequest(response.ErrorResponse($"No se encontro ningun usuario con: ", auth));
            ContractedPlans? contratosPlan = _context.ContractedPlans
                                                     .Include(x => x.Client)
                                                     .Include(x => x.Plan)
                                                     .Where(x => x.UserId.ToString() == user.Id.ToString()).FirstOrDefault();
            SyncUpData sincronizarData = new()
            {
                contractedPlans = contratosPlan
            };
            return Ok(response.SuccessResponse("Inicio de sesión exitoso, bienvenido", sincronizarData));
        }


        [HttpGet("plan-by-cliente/{email}")]
        public IActionResult PlanByClient(string email)
        {
            Users? user = _context.Users.Where(x => x.Email == email && x.EmailVerified == StateEnum.ENABLED).FirstOrDefault();
            if (user is null)
                return BadRequest(response.ErrorResponse($"No se encontro ningun usuario con: ", email));
            ContractedPlans? contratosPlan = _context.ContractedPlans
                                                     .Include(x => x.Client)
                                                     .Include(x => x.Plan)
                                                     .Where(x => x.UserId.ToString() == user.Id.ToString()).FirstOrDefault();
            SyncUpData sincronizarData = new()
            {
                contractedPlans = contratosPlan
            };
            return Ok(response.SuccessResponse("Inicio de sesión exitoso, bienvenido", sincronizarData));
        }


        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto reset)
        {
            try
            {
                if (_userService.FindUserByEmail(reset.Email) is null)
                    return BadRequest(response.ErrorResponse($"Correo electrónico no registrado", reset));

                RestorePassword resetPass = _passwordService.RestorePassword(reset.Email);

                _context.RestorePassword.Add(resetPass);
                _context.SaveChanges();
                // AQUI VA EL EMAIL
                string urlBaseCliente = Request.Headers.Referer;
                _mailingService.sendMail(reset.Email,
                                         new
                                         {
                                             urlBaseFront = urlBaseCliente.Replace("/login", ""),
                                             email = resetPass.Email,
                                             guid = resetPass.Id
                                         },
                                             TypesMail.RESTORE_EMAIL);
                return Ok(response.SuccessResponse("Éxito, revise su bandeja de entrada para restaurar su contraseña", reset));
            }
            catch (Exception ex)
            {
                return BadRequest(response.ErrorResponse($"{ex.Message}", reset));
            }
        }
        [HttpPost("restore-password")]
        public IActionResult RestorePassword([FromBody] RestorePasswordDto restore)
        {
            RestorePassword? ID = _passwordService.VerifyId(restore.Id);
            if (ID is null)
                return BadRequest(response.ErrorResponse("El link enviado es inválido", restore));

            Users? user = _userService.FindUserByEmail(ID.Email);
            if (user is null)
                return BadRequest(response.ErrorResponse("El link enviado es inválido", restore));

            Users updated = _passwordService.UpdatePassword(user, restore.Password);
            UserDto userDto = _mapper.Map<UserDto>(updated);
            _context.Users.Update(updated);
            _context.RestorePassword.Remove(ID);
            _context.SaveChanges();
            return Ok(response.SuccessResponse("Su contraseña se ha actualizado", userDto));
        }

        [HttpPut("update-user")]
        [Authorize]
        public IActionResult UpdateUser([FromBody] UpdateClienteDto userUpdate)
        {
            string? idUser = _userService.GetUserLoggedId();
            if (idUser is null)
                return BadRequest(response.SuccessResponse("No se encontró el usuario", userUpdate));

            string message = "Usuario actualizado. ";
            Users user = _context.Users.FirstOrDefault(x => x.Id.ToString() == idUser)!;
            if (!user.Email.Equals(userUpdate.Email))
            {
                if (_userService.FindUserByEmail(userUpdate.Email) is not null)
                    return BadRequest(response.ErrorResponse("Intente con un correo electrónico diferente", userUpdate));
                message += "Ha actualizado su correo electrónico, revise su bandeja de entrada para activar su cuenta";
                // Aqui va el email
            }
            Users updated = _userService.UpdateInfo(user, userUpdate);
            UserDto userDto = _mapper.Map<UserDto>(updated);
            _context.Users.Update(updated);
            _context.SaveChanges();
            return Ok(response.SuccessResponse(message, userDto));
        }

        [HttpGet("validate-user/{email}")]
        public ActionResult validateUser(string email, string urlBaseClient = "")
        {
            string urlBaseront = $"{urlBaseClient}/login";
            Users? user = _context.Users.Where(x => x.Email == email && x.EmailVerified == StateEnum.DISABLED).FirstOrDefault();
            if (user != null)
            {
                user.EmailVerified = StateEnum.ENABLED;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            return Redirect(urlBaseront);
        }

        [HttpPost("verify-email")]
        public ActionResult VerifyEmail(CustomerDto customer)
        {
            string? userId = _userService.GetUserLoggedId();

            Users? user = new();

            if(userId is not null)
            {
                user = _context.Users.Include(x => x.ContractedPlans).FirstOrDefault(x => x.Id.ToString() == userId);
                if(user.ContractedPlans.Count > 0)
                    return BadRequest(response.ErrorResponse("Ya tiene un plan registrado, si desea comprar otro plan, debe crear otro usuario con diferente correo electrónico", customer.Email));
            }


            user = _context.Users.Include(x => x.ContractedPlans).FirstOrDefault(x => x.Email == customer.Email);

            if(user is not null && user.ContractedPlans.Count > 0)
                return BadRequest(response.ErrorResponse("Ya tenemos registrado ese correo electronico, inicie sesión o intente con un correo diferente", customer.Email));

            Guests guest = new()
            {
                firstName = customer.FirstName,
                lastName = customer.LastName,
                email = customer.Email,
                phone = customer.Phone,
            };

            _context.Guests.Add(guest);
            _context.SaveChanges();

            return Ok(response.SuccessResponse("Ok", customer.Email));
        }

        [HttpGet("my-info")]
        [Authorize]
        public ActionResult WhoIAm()
        {
            string userId = _userService.GetUserLoggedId()!;
            UserDto user = _userService.WhoIAm(userId);
            return Ok(response.SuccessResponse("Ok", user));
        }

        [HttpPut("update-password")]
        [Authorize]
        public IActionResult UpdatePassword([FromBody] UpdatePasswordDto data)
        {
            string userId = _userService.GetUserLoggedId()!;
            Users? user = _userService.FindUserById(userId);
            if (user is null) return BadRequest(response.ErrorResponse("No se encontró el usuario", user));

            if (!_userService.VerifyPassword(data.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest(response.ErrorResponse("Contraseña actual incorrecta", user));
            UserDto userDto = _userService.UpdatePassword(data, user);
            _context.SaveChanges();
            return Ok(response.ErrorResponse("Contraseña actualizada correctamente", userDto));
        }

        private string urlBaseSendEmail(string email)
        {
            string urlBaseCliente = Request.Headers.Referer;
            urlBaseCliente = urlBaseCliente.Replace("/register", "");
            var request = _httpContext.HttpContext.Request;
            string urlBaseImage = request.Host.Value;
            return $"{request.Scheme}://{urlBaseImage}/agw/api/user/validate-user/{email}?urlBaseClient={urlBaseCliente}";
        }
    }
}
