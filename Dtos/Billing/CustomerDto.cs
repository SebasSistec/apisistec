namespace apisistec.Dtos.Billing
{
    public class CustomerDto
    {
        public string? Id { get; set; }
        public string Identification { get; set; } = null!;
        public int IdentificationType { get; set; } = 1;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ProvinceInec { get; set; } = null!;
        public string CantonInec { get; set; } = null!;
        public bool PriorityTradeName { get; set; } = false;
        public string? Password { get; set; } = string.Empty;
    }
}
