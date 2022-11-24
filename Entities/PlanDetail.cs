namespace apisistec.Entities
{
    public class PlanDetail
    {
        public PlanDetail()
        {
            PlanHeaderXDetail = new List<PlanHeaderXDetail>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<PlanHeaderXDetail> PlanHeaderXDetail { get; set; }
    }
}
