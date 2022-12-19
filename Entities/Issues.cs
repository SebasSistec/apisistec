using apisistec.Enums;

namespace apisistec.Entities
{
    public class Issues
    {
        public Guid id { get; set; }
        public int orderNumber { get; set; }
        public TaskStateEnum state { get; set; } = TaskStateEnum.ENABLED;
        public DateTime createdAt { get; set; } = DateTime.Now;
        public IssuePriorityEnum priority { get; set; }
        public string asignedById { get; set; }
        public string asignedToId { get; set; }
        public string clientId { get; set; } = null!;
        public Guid projectId { get; set; }
        public Empleado asignedBy { get; set; } = null!;
        public Empleado asignedTo { get; set; } = null!;
        public Cliente client { get; set; } = null!;
        public Projects project { get; set; } = null!;
        public List<IssueDetails> issueDetails { get; set; } = new();
    }
}
