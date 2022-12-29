namespace apisistec.Entities
{
    public class Modules
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string name { get; set; }
        public string description { get; set; } = string.Empty;
        public DateTime createdAt { get; set; } = DateTime.Now;
        public List<IssueDetails> issueDetails { get; set; } = new();
    }
}
