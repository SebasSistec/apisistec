using apisistec.Dtos.Support;

namespace apisistec.Entities
{
    public class IssueTimings : IssueTimingDto
    {
        public Guid issueDetailId { get; set; }
        public IssueDetails detail { get; set; }
    }
}
