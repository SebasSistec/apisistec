using apisistec.Enums;

namespace apisistec.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public StateEnum State { get; set; }
        public StateEnum EmailVerified { get; set; }
        public string PasswordTemp { get; set; } = string.Empty;
        public List<ContractedPlans> ContractedPlans { get; set; } = new();
    }
}
