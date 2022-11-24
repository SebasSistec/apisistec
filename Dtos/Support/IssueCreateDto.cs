
using apisistec.Enums;

namespace apisistec.Dtos.Support
{
    public class IssueCreateDto
    {
        public string asignToId { get; set; } = null!;
        public string clientId { get; set; } = null!;
        public IssuePriorityEnum priority { get; set; }
        public List<IssueDetailDto> details { get; set; }
    }
}
