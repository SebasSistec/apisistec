using apisistec.Entities;
using apisistec.Enums;

namespace apisistec.Models.Parameters.Support
{
    public class SupportQParams : QueryParams
    {
        public SupportQParams()
        {
            orderBy = nameof(Issues.createdAt);
        }

        public DateTime? minDate { get; set; }
        public DateTime? maxDate { get; set; }
        public bool validFechaRegistroRange => maxDate >= minDate;
        public string? orderNum { get; set; }
        public IssuePriorityEnum? priority { get; set; }
        public IssueStateEnum? detailState { get; set; }
        public string[]? clients { get; set; }
        public string[]? employees { get; set; }
        public string[]? products { get; set; }
        public Guid[]? projects { get; set; }
    }
}
