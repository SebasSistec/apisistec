using apisistec.Dtos.Support;
using apisistec.Enums;

namespace apisistec.Entities
{
    public class IssueTimings
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public IssueStateEnum state { get; set; } = IssueStateEnum.PENDING;
        public DateTime? startAt { get; set; }
        public DateTime? endAt { get; set; }
        public string? pauseDescription { get; set; }
        public DateTime createdAt { get; set; }
        public Guid issueDetailId { get; set; }
        public IssueDetails detail { get; set; }
        public string employeeId { get; set; }
        public Empleado employee { get; set; }
    }
}
