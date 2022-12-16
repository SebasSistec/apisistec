
using apisistec.Enums;

namespace apisistec.Dtos.Support
{
    public class IssueCreateDto
    {
        public string asignToId { get; set; } = null!;
        public string clientId { get; set; } = null!;
        public Guid projectId { get; set; }
        public IssuePriorityEnum priority { get; set; }
        public List<IssueDetailDto> details { get; set; }
    }
}
