using Models;

namespace apisistec.Entities
{
    public class IssueDetails
    {
        public Guid id { get; set; }
        public string title { get; set; } = null!;
        public string description { get; set; } = null!;
        public string? solution { get; set; }
        public decimal estimatedHours { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public string productId { get; set; }
        public string employeeId { get; set; }
        public Guid issueId { get; set; }
        public Guid moduleId { get; set; }
        public Issues issue { get; set; }
        public Producto producto { get; set; }
        public Empleado empleado { get; set; }
        public Modules module { get; set; }
        public List<IssueTimings> timings { get; set; } = new();
        public List<IssueFiles> files { get; set; } = new();
    }
}
