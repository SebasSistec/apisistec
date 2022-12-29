using apisistec.Dtos.Employee;
using apisistec.Dtos.File;
using apisistec.Dtos.Product;
using apisistec.Enums;

namespace apisistec.Dtos.Support
{
    public class IssueDetailDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public double estimatedHours { get; set; }
        public EmployeeDto employee { get; set; }
        public ProductDto product { get; set; }
        public Guid moduleId { get; set; }
        public List<FileUploadedDto> cacheFileKeys { get; set; }
    }
}
