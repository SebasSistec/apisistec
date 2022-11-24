namespace apisistec.Entities
{
    public class IssueFiles
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string extension { get; set; }
        public DateTime createdAt { get; set; }
        public Guid issueDetailId { get; set; }
        public IssueDetails detail { get; set; }
    }
}
