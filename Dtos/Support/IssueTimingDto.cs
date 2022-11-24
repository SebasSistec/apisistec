using apisistec.Enums;

namespace apisistec.Dtos.Support
{
    public class IssueTimingDto
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public IssueStateEnum state { get; set; } = IssueStateEnum.PENDING;
        public DateTime? startAt { get; set; } 
        public DateTime? endAt { get; set; }
        public string? pauseDescription { get; set; }
    }
}
