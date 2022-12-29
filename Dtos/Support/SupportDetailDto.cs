using apisistec.Dtos.File;
using apisistec.Dtos.Product;
using apisistec.Dtos.Project;
using apisistec.Entities;

namespace apisistec.Dtos.Support
{
    public class SupportDetailDto
    {
        public Guid id { get; set; }
        public string title { get; set; } = null!;
        public string description { get; set; } = null!;
        public string? solution { get; set; } = string.Empty;
        public decimal estimatedHours { get; set; }
        public ProjectOrModuleDto module { get; set; }
        public ProductDto product { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public IssueTimingDto timing { get; set; }
        public List<FileResponseDto> files { get; set; } = new();
    }
}
