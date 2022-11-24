namespace apisistec.Entities
{
    public class Guests
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}
