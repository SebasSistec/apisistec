using apisistec.Dtos.Client;
using apisistec.Dtos.Employee;
using apisistec.Dtos.Project;
using apisistec.Enums;

namespace apisistec.Dtos.Support
{
    public class SupportDto
    {
        public Guid id { get; set; }
        public int orderNumber { get; set; }
        public TaskStateEnum state { get; set; } 
        public DateTime createdAt { get; set; }
        public EmployeeDto asignedBy { get; set; }
        public ClientDto client { get; set; }
        public ProjectDto project { get; set; }
        public List<SupportDetailDto> details { get; set; }
    }
}
