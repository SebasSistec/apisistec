using apisistec.Enums;

namespace apisistec.Dtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public StateEnum? State { get; set; } = StateEnum.DISABLED;
    }
}
