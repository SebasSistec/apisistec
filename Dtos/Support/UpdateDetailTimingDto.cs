using apisistec.Enums;

namespace apisistec.Dtos.Support
{
    public class UpdateDetailTimingDto
    {
        public Guid id { get; set; }
        public IssueStateEnum state { get; set; }
        public string? pauseDescription { get; set; }
        public string? solution { get; set; }
    }
}
